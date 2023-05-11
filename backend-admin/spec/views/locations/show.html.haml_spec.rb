# frozen_string_literal: true

require 'rails_helper'

RSpec.describe 'locations/show', type: :view do
  before(:each) do
    assign(:location, Location.create!(
                        title: 'Title',
                        description: 'MyText',
                        address: 'Address',
                        country: 'Country',
                        city: 'City',
                        state: 'State',
                        image: 'Image',
                        short_describtion: 'MyText',
                        latitude: 2.5,
                        longitude: 3.5,
                        comment: 'Comment',
                        user: nil
                      ))
  end

  it 'renders attributes in <p>' do
    render
    expect(rendered).to match(/Title/)
    expect(rendered).to match(/MyText/)
    expect(rendered).to match(/Address/)
    expect(rendered).to match(/Country/)
    expect(rendered).to match(/City/)
    expect(rendered).to match(/State/)
    expect(rendered).to match(/Image/)
    expect(rendered).to match(/MyText/)
    expect(rendered).to match(/2.5/)
    expect(rendered).to match(/3.5/)
    expect(rendered).to match(/Comment/)
    expect(rendered).to match(//)
  end
end
