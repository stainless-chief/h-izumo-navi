require 'rails_helper'

RSpec.describe "reviews/new", type: :view do
  before(:each) do
    assign(:review, Review.new(
      title: "MyString",
      rating: 1,
      body: "MyText",
      user: nil,
      location: nil
    ))
  end

  it "renders new review form" do
    render

    assert_select "form[action=?][method=?]", reviews_path, "post" do

      assert_select "input[name=?]", "review[title]"

      assert_select "input[name=?]", "review[rating]"

      assert_select "textarea[name=?]", "review[body]"

      assert_select "input[name=?]", "review[user_id]"

      assert_select "input[name=?]", "review[location_id]"
    end
  end
end
