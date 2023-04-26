class CreateLocations < ActiveRecord::Migration[7.0]
  def change
    create_table :locations do |t|
      t.string :title
      t.string :short_discription
      t.string :discription
      t.string :address
      t.string :city
      t.string :state
      t.string :country
      t.string :image

      t.timestamps
    end
  end
end
