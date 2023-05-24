# frozen_string_literal: true

module LocationsHelper
  def location_rating_percentage(location:, rating:)
    return 0 if location.reviews.count.nil? || location.reviews.count.zero? 

    ((location.reviews.where(rating: rating).size.to_f / location.reviews.count) * 100).to_i
  end
end
