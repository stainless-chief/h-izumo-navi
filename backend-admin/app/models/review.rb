class Review < ApplicationRecord
  validates :title, presence: true
  validates :body, presence: true
  validates :rating, presence: true, numericality: { greater_then_or_equal_to: 1, less_then_or_equal_to: 5, only_integer: true }
  belongs_to :user
  belongs_to :location
  after_commit :update_average_rating, on: %i[create update]

  def update_average_rating
    location.update!(average_rating: location.reviews.average(:rating))
  end
end
