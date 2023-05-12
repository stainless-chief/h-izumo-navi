json.extract! review, :id, :title, :rating, :body, :user_id, :location_id, :created_at, :updated_at
json.url review_url(review, format: :json)
