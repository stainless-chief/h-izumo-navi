# frozen_string_literal: true

class LikesController < ApplicationController
  def create
    @like = current_user.likes.new(like_params)
    flash[:notice] = @like.errors.full_messages.to_sentence unless @like.save
    redirect_to request.fullpath
  end

  def destroy
    @like = current_user.likes.find(params[:id])
    location = @like.location
    @like.destroy
    redirect_to request.fullpath
  end

  private

  def like_params
    params.require(:like).permit(:location_id)
  end
end
