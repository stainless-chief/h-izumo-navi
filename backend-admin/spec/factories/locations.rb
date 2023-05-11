# frozen_string_literal: true

# == Schema Information
#
# Table name: locations
#
#  id                :bigint           not null, primary key
#  title             :string
#  description       :text
#  short_describtion :text
#  address           :string
#  country           :string
#  city              :string
#  state             :string
#  image             :string
#  latitude          :float
#  longitude         :float
#  comment           :string
#  user_id           :bigint           not null
#  created_at        :datetime         not null
#  updated_at        :datetime         not null
#  was_here          :boolean
#  meet_time         :time
#
FactoryBot.define do
  factory :location do
    title { 'MyString' }
    description { 'MyText' }
    address { 'MyString' }
    country { 'MyString' }
    city { 'MyString' }
    state { 'MyString' }
    image { 'MyString' }
    short_describtion { 'MyText' }
    latitude { 1.5 }
    longitude { 1.5 }
    comment { 'MyString' }
    user { nil }
  end
end
