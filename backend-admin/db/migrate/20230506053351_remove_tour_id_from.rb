class RemoveTourIdFrom < ActiveRecord::Migration[7.0]
  def change
    remove_foreign_key :locations, column: :tour_id
  end
end
