class Tour < ApplicationRecord
  has_many :locations, dependent: :destroy, inverse_of: :tour
  # _destroy is a special attribute that is used to mark a record for destruction
  accepts_nested_attributes_for :locations, allow_destroy: true, reject_if: :all_blank
end
