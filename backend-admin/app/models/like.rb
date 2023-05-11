# frozen_string_literal: true

class Like < ApplicationRecord
  validates :user_id, uniqueness: { scope: :location_id }
  belongs_to :user
  belongs_to :location
end
