# frozen_string_literal: true

# == Schema Information
#
# Table name: favorites
#
#  id          :bigint           not null, primary key
#  user_id     :bigint           not null
#  location_id :bigint           not null
#  created_at  :datetime         not null
#  updated_at  :datetime         not null
#
class Favorite < ApplicationRecord
  validates :user_id, uniqueness: { scope: :location_id }
  belongs_to :user
  belongs_to :location
end
