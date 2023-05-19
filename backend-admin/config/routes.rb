# frozen_string_literal: true

Rails.application.routes.draw do
  get 'admin/dashboard'
  get 'call', to: 'call#user', as: 'call_user'
  post 'call', to: 'call#create'

  root 'home#index'
  get 'home/about', to: 'home#about', as: 'about'
  get 'user/:id', to: 'users#show', as: 'user'
  get 'single_show/:id', to: 'users#single_show', as: 'info'
  get 'users', to: 'users#index'
  get 'favorites', to: 'locations#favorites'
  get 'life_chat', to: 'rooms#index'
  # leave_room_path(room)
  get 'rooms/leave/:id', to: 'rooms#leave', as: 'leave_room'
  # join_room_path(room)
  get 'rooms/join/:id', to: 'rooms#join', as: 'join_room'
  
  resources :locations
  resources :reviews
  resources :likes, only: %i[create destroy]
  resources :rooms do
    resources :messages
    collection do
      post :search
    end
  end
  devise_for :users, skip: :omniauth_callbacks, controllers: {
    sessions: 'users/sessions',
    registrations: 'users/registrations',
    confirmations: 'users/confirmations'
  }

  namespace :api do
    resources :favorites, only: %i[create destroy]
  end
end
