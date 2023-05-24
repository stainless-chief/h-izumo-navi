class User < ApplicationRecord
  # Include default devise modules. Others available are:
  # :confirmable, :lockable, :timeoutable, :trackable and :omniauthable
  devise :database_authenticatable, :registerable,
         :recoverable, :rememberable, :validatable
  enum role: %i[user admin]
  enum status: %i[offline away online dnd]
  has_many :locations
  has_many :likes
  has_many :favorites, dependent: :destroy
  has_many :favorited_products, through: :favorites, source: :location
  has_many :reviews, dependent: :destroy
  scope :all_except, ->(user) { where.not(id: user) }
  after_create_commit { broadcast_append_to 'users' }
  after_update_commit { broadcast_update }
  after_initialize :set_default_role, if: :new_record?
  has_many :messages
  has_one_attached :avatar
  after_commit :add_default_avatar, on: %i[create update]
  has_many :joinables, dependent: :destroy
  has_many :joined_rooms, through: :joinables, source: :room
  has_many :notifications, dependent: :destroy, as: :recipient
  validates_uniqueness_of :name, required: true, case_sensitive: false

  def avatar_thumbnail
    avatar.variant(resize_to_limit: [150, 150]).processed
  end

  def chat_avatar
    avatar.variant(resize_to_limit: [50, 50]).processed
  end

  def broadcast_update
    broadcast_replace_to 'user_status', partial: 'users/status', user: self
  end

  def has_joined_room(room)
    joined_rooms.include?(room)
  end

  def status_to_css
    case status
    when 'online'
      'bg-success'
    when 'away'
      'bg-warning'
    when 'offline'
      'bg-dark'
    when 'dnd'
      'bg-danger'
    else
      'bg-dark'
    end
  end

  # def name
  #   "#{first_name} #{last_name}".squish
  # end


  private

  def set_default_role
    if @user == User.first
      self.role = :admin
    else
      self.role ||= :user
    end
  end

  def add_default_avatar
    return if avatar.attached?

    avatar.attach(
      io: File.open(Rails.root.join('app', 'assets', 'images', 'anonimus.png')),
      filename: 'anonimus.png',
      content_type: 'image/png'
    )
  end
end
