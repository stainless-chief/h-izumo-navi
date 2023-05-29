# frozen_string_literal: true

# Controller for analitics

class AnaliticsController < ApplicationController
  protect_from_forgery with: :null_session

  def create
    analitics = Analitic.create!(analitics_params)

    respond_to do |format|
      format.json do
        render json: serialize_analitics(analitics), status: :created
      end
    end
  end

  private

  def analitics_params
    params.permit(:user_id, :product_id, :location_latitude, :location_longitude)
  end

  def serialize_analitics(analitics)
    AnaliticsSerializer.new(analitics).serializable_hash[:data].to_json
  end
end

