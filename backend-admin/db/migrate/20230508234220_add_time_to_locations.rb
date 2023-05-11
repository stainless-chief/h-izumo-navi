# frozen_string_literal: true

class AddTimeToLocations < ActiveRecord::Migration[7.0]
  def change
    add_column :locations, :meet_time, :time
  end
end
