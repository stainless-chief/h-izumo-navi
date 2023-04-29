class AddUserToTours < ActiveRecord::Migration[7.0]
  def change
    add_reference :tours, :user, foreign_key: true
  end
end
