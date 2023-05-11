# frozen_string_literal: true

class CreateLocations < ActiveRecord::Migration[7.0]
  def change
    create_table :locations do |t|
      t.string :title
      t.text :description
      t.text :short_describtion
      t.string :address
      t.string :country
      t.string :city
      t.string :state
      t.string :image
      t.float :latitude, precision: 10, scale: 6
      t.float :longitude, precision: 10, scale: 6
      t.string :comment
      t.references :user, null: false, foreign_key: true

      t.timestamps
    end
  end
end
