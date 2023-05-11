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
FactoryBot.define do
  factory :favorite do
    user { nil }
    location { nil }
  end
end
