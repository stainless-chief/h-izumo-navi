require 'rails_helper'

RSpec.describe "locations/new", type: :view do
  before(:each) do
    assign(:location, Location.new(
      title: "MyString",
      description: "MyText",
      address: "MyString",
      country: "MyString",
      city: "MyString",
      state: "MyString",
      image: "MyString",
      short_discription: "MyText",
      latitude: 1.5,
      longitude: 1.5
    ))
  end

  it "renders new location form" do
    render

    assert_select "form[action=?][method=?]", locations_path, "post" do

      assert_select "input[name=?]", "location[title]"

      assert_select "textarea[name=?]", "location[description]"

      assert_select "input[name=?]", "location[address]"

      assert_select "input[name=?]", "location[country]"

      assert_select "input[name=?]", "location[city]"

      assert_select "input[name=?]", "location[state]"

      assert_select "input[name=?]", "location[image]"

      assert_select "textarea[name=?]", "location[short_discription]"

      assert_select "input[name=?]", "location[latitude]"

      assert_select "input[name=?]", "location[longitude]"
    end
  end
end
