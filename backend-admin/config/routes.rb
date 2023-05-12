# frozen_string_literal: true

Rails.application.routes.draw do
  root 'home#index'
  get 'home/about', to: 'home#about', as: 'about'
  get 'show/:id', to: 'users#show', as: 'info'
  get 'users', to: 'users#index'
  get 'favorites', to: 'locations#favorites'
  resources :locations
  resources :reviews
  resources :likes, only: %i[create destroy]
  

  devise_for :users
  namespace :api do
    resources :favorites, only: %i[create destroy]
  end
end
