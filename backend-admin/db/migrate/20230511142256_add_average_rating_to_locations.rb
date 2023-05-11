class AddAverageRatingToLocations < ActiveRecord::Migration[7.0]
  def change
    add_column :locations, :average_rating, :decimal
  end
end
