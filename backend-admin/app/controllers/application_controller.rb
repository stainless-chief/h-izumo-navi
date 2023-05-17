# frozen_string_literal: true

class ApplicationController < ActionController::Base
  include Pagy::Backend
  protect_from_forgery with: :null_session
  before_action :authenticate_user!
  before_action :turbo_frame_request_variant
  before_action :set_current_user

  private

  def turbo_frame_request_variant
    request.variant = :turbo_frame if turbo_frame_request?
  end

  def set_current_user
    Current.user = current_user
  end
end
