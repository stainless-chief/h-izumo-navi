# frozen_string_literal: true

Rails.application.routes.draw do
  
  root 'home#index'
  get 'home/about', to: 'home#about', as: 'about'
  get 'user/:id', to: 'users#show', as: 'user'
  get 'single_show/:id', to: 'users#single_show', as: 'info'
  get 'users', to: 'users#index'
  get 'favorites', to: 'locations#favorites'
  get 'life_chat', to: 'rooms#index'
  resources :locations
  resources :reviews
  resources :likes, only: %i[create destroy]
  resources :rooms do
    resources :messages
  end
  devise_for :users
  devise_scope :user do
    get 'users', to: 'devise/sessions#new'
  end
  namespace :api do
    resources :favorites, only: %i[create destroy]
  end
end
