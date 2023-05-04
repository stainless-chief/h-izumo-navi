# frozen_string_literal: true

Rails.application.routes.draw do
  root 'home#index'
  resources :locations
  resources :tours
  devise_for :users
end
