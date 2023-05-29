# frozen_string_literal: true

# == Schema Information
#
# Table name: locations
class Location < ApplicationRecord
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

  def sended_analitics?(user)
    return if user.nil?

    sended_analitics.include?(user)
  end
end
