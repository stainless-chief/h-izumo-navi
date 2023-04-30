class CreateLocations < ActiveRecord::Migration[7.0]
  def change
    create_table :locations do |t|
      t.string :title
      t.text :description
      t.string :address
      t.string :country
      t.string :city
      t.string :state
      t.string :image
      t.text :short_discription
      t.float :latitude
      t.float :longitude

      t.timestamps
    end
  end
end
