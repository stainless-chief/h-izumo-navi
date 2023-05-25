# frozen_string_literal: true

class HomeController < ApplicationController
  # after_action :set_status

  def index; end

  def about; end

  def question; end

  private

  def set_status
    current_user&.update!(status: User.statuses[:offline])
  end
end
