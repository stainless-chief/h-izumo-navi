# frozen_string_literal: true

Rails.application.routes.draw do
  root 'home#index'
  get 'home/about', to: 'home#about', as: 'about'
  resources :locations
  resources :tours
  devise_for :users
end
