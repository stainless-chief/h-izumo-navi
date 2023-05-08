require 'rails_helper'

RSpec.describe "locations/index", type: :view do
  before(:each) do
    assign(:locations, [
      Location.create!(
        title: "Title",
        description: "MyText",
        address: "Address",
        country: "Country",
        city: "City",
        state: "State",
        image: "Image",
        short_describtion: "MyText",
        latitude: 2.5,
        longitude: 3.5,
        comment: "Comment",
        user: nil
      ),
      Location.create!(
        title: "Title",
        description: "MyText",
        address: "Address",
        country: "Country",
        city: "City",
        state: "State",
        image: "Image",
        short_describtion: "MyText",
        latitude: 2.5,
        longitude: 3.5,
        comment: "Comment",
        user: nil
      )
    ])
  end

  it "renders a list of locations" do
    render
    cell_selector = Rails::VERSION::STRING >= '7' ? 'div>p' : 'tr>td'
    assert_select cell_selector, text: Regexp.new("Title".to_s), count: 2
    assert_select cell_selector, text: Regexp.new("MyText".to_s), count: 2
    assert_select cell_selector, text: Regexp.new("Address".to_s), count: 2
    assert_select cell_selector, text: Regexp.new("Country".to_s), count: 2
    assert_select cell_selector, text: Regexp.new("City".to_s), count: 2
    assert_select cell_selector, text: Regexp.new("State".to_s), count: 2
    assert_select cell_selector, text: Regexp.new("Image".to_s), count: 2
    assert_select cell_selector, text: Regexp.new("MyText".to_s), count: 2
    assert_select cell_selector, text: Regexp.new(2.5.to_s), count: 2
    assert_select cell_selector, text: Regexp.new(3.5.to_s), count: 2
    assert_select cell_selector, text: Regexp.new("Comment".to_s), count: 2
    assert_select cell_selector, text: Regexp.new(nil.to_s), count: 2
  end
end
