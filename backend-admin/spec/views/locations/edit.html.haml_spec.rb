# frozen_string_literal: true

require 'rails_helper'

RSpec.describe 'locations/edit', type: :view do
  let(:location) do
    Location.create!(
      title: 'MyString',
      description: 'MyText',
      address: 'MyString',
      country: 'MyString',
      city: 'MyString',
      state: 'MyString',
      image: 'MyString',
      short_describtion: 'MyText',
      latitude: 1.5,
      longitude: 1.5,
      comment: 'MyString',
      user: nil
    )
  end

  before(:each) do
    assign(:location, location)
  end

  it 'renders the edit location form' do
    render

    assert_select 'form[action=?][method=?]', location_path(location), 'post' do
      assert_select 'input[name=?]', 'location[title]'

      assert_select 'textarea[name=?]', 'location[description]'

      assert_select 'input[name=?]', 'location[address]'

      assert_select 'input[name=?]', 'location[country]'

      assert_select 'input[name=?]', 'location[city]'

      assert_select 'input[name=?]', 'location[state]'

      assert_select 'input[name=?]', 'location[image]'

      assert_select 'textarea[name=?]', 'location[short_describtion]'

      assert_select 'input[name=?]', 'location[latitude]'

      assert_select 'input[name=?]', 'location[longitude]'

      assert_select 'input[name=?]', 'location[comment]'

      assert_select 'input[name=?]', 'location[user_id]'
    end
  end
end
