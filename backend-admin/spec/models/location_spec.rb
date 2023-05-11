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
require 'rails_helper'

RSpec.describe Location, type: :model do
  pending "add some examples to (or delete) #{__FILE__}"
end
