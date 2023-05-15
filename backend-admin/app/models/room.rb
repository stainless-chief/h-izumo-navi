class Room < ApplicationRecord
  validates_uniqueness_of :name
  scope :public_rooms, -> { where(is_private: false) }
  after_update_commit { broadcast_if_public }
  has_many :messages
end
