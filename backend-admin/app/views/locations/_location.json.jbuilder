# frozen_string_literal: true

json.extract! location, :id, :title, :description, :address, :country, :city, :state, :image, :short_discription, :latitude, :longitude, :created_at, :updated_at
json.url location_url(location, format: :json)
