class Location < ApplicationRecord
  mount_uploader :image, ImageUploader
  belongs_to :user
  belongs_to :tour, inverse_of: :locations
end
