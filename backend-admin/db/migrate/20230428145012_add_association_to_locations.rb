class AddAssociationToLocations < ActiveRecord::Migration[7.0]
  def change
    add_reference :locations, :tour, foreign_key: true
  end
end
