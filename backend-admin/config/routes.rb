# frozen_string_literal: true

Rails.application.routes.draw do
  resources :locations
  resources :tours
  devise_for :users
  root 'home#index'
end
