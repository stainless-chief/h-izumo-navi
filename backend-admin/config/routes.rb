Rails.application.routes.draw do
  root 'home#index'
  get 'home/about', to: 'home#about', as: 'about'
  get 'home/question', to: 'home#question', as: 'question'
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
  
  resources :analitics, only: [:create]

  devise_for :users, skip: :omniauth_callbacks, controllers: {
    sessions: 'users/sessions',
    registrations: 'users/registrations',
    confirmations: 'users/confirmations'
  }
  namespace :api do
    resources :favorites, only: %i[create destroy]
  end
end
