json.extract! location, :id, :title, :short_discription, :discription, :address, :city, :state, :country, :image, :created_at, :updated_at
json.url location_url(location, format: :json)
