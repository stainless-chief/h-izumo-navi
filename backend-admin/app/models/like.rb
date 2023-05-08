class Like < ApplicationRecord
  validates :user_id, uniqueness: { scope: :tour_id }
  belongs_to :user
  belongs_to :tour
end
