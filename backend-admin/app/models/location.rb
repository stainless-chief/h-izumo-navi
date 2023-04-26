class Location < ApplicationRecord
  mount_uploader :image, ImageUploader
end
