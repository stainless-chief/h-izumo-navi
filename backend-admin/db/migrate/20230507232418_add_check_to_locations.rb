# frozen_string_literal: true

class AddCheckToLocations < ActiveRecord::Migration[7.0]
  def change
    add_column :locations, :was_here, :boolean
  end
end
