class Location < ApplicationRecord
  mount_uploader :image, ImageUploader
  belongs_to :tour
end
