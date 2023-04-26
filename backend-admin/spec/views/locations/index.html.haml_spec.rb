require 'rails_helper'

RSpec.describe "locations/index", type: :view do
  before(:each) do
    assign(:locations, [
      Location.create!(
        title: "Title",
        short_discription: "Short Discription",
        discription: "Discription",
        address: "Address",
        city: "City",
        state: "State",
        country: "Country",
        image: "Image"
      ),
      Location.create!(
        title: "Title",
        short_discription: "Short Discription",
        discription: "Discription",
        address: "Address",
        city: "City",
        state: "State",
        country: "Country",
        image: "Image"
      )
    ])
  end

  it "renders a list of locations" do
    render
    cell_selector = Rails::VERSION::STRING >= '7' ? 'div>p' : 'tr>td'
    assert_select cell_selector, text: Regexp.new("Title".to_s), count: 2
    assert_select cell_selector, text: Regexp.new("Short Discription".to_s), count: 2
    assert_select cell_selector, text: Regexp.new("Discription".to_s), count: 2
    assert_select cell_selector, text: Regexp.new("Address".to_s), count: 2
    assert_select cell_selector, text: Regexp.new("City".to_s), count: 2
    assert_select cell_selector, text: Regexp.new("State".to_s), count: 2
    assert_select cell_selector, text: Regexp.new("Country".to_s), count: 2
    assert_select cell_selector, text: Regexp.new("Image".to_s), count: 2
  end
end
