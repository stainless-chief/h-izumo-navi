class Location < ApplicationRecord
  mount_uploader :image, ImageUploader
  belongs_to :user
  has_many :likes
  has_many :favorites, dependent: :destroy
  has_many :favorited_users, through: :favorites, source: :user

  def favorited_by?(user)
    return if user.nil?

    favorited_users.include?(user)
  end
end
