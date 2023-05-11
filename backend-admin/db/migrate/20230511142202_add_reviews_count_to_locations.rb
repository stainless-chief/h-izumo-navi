class AddReviewsCountToLocations < ActiveRecord::Migration[7.0]
  def change
    add_column :locations, :reviews_count, :integer
  end
end
