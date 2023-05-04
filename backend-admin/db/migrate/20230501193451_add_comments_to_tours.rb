class AddCommentsToTours < ActiveRecord::Migration[7.0]
  def change
    add_column :tours, :comment, :string
  end
end
