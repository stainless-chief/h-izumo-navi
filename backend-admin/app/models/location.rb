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
class Location < ApplicationRecord
  include CarrierWave::MiniMagick
  mount_uploader :image, ImageUploader
  belongs_to :user
  has_many :likes
  has_many :favorites, dependent: :destroy
  has_many :favorited_users, through: :favorites, source: :user
  has_many :reviews

  def favorited_by?(user)
    return if user.nil?

    favorited_users.include?(user)
  end
end
