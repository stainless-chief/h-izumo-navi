# frozen_string_literal: true

# Helper for chat rooms
module RoomsHelper
  def search_rooms
    if params[:name_search].present? && params[:name_search].length.positive?
      Room.public_rooms
          .where
          .not(id: current_user.joined_rooms.pluck(:id))
          .where('name ILIKE ?', "%#{params[:name_search]}%")
          .order(name: :asc)
    else
      []
    end
  end

  def get_name(user1, user2)
    user = [user1, user2].sort
    "private_#{user[0].id}_#{user[1].id}"
  end
end
