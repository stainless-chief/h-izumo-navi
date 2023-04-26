class Tour < ApplicationRecord
  has_many :locations
  belongs_to :user
  accepts_nested_attributes_for :locations, allow_destroy: true
end
