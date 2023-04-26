require 'rails_helper'

RSpec.describe "locations/edit", type: :view do
  let(:location) {
    Location.create!(
      title: "MyString",
      short_discription: "MyString",
      discription: "MyString",
      address: "MyString",
      city: "MyString",
      state: "MyString",
      country: "MyString",
      image: "MyString"
    )
  }

  before(:each) do
    assign(:location, location)
  end

  it "renders the edit location form" do
    render

    assert_select "form[action=?][method=?]", location_path(location), "post" do

      assert_select "input[name=?]", "location[title]"

      assert_select "input[name=?]", "location[short_discription]"

      assert_select "input[name=?]", "location[discription]"

      assert_select "input[name=?]", "location[address]"

      assert_select "input[name=?]", "location[city]"

      assert_select "input[name=?]", "location[state]"

      assert_select "input[name=?]", "location[country]"

      assert_select "input[name=?]", "location[image]"
    end
  end
end
