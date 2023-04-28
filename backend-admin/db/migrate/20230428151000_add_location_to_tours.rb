class AddLocationToTours < ActiveRecord::Migration[7.0]
  def change
    add_column :tours, :location, :string
  end
end
