require 'rails_helper'

RSpec.describe "reviews/edit", type: :view do
  let(:review) {
    Review.create!(
      title: "MyString",
      rating: 1,
      body: "MyText",
      user: nil,
      location: nil
    )
  }

  before(:each) do
    assign(:review, review)
  end

  it "renders the edit review form" do
    render

    assert_select "form[action=?][method=?]", review_path(review), "post" do

      assert_select "input[name=?]", "review[title]"

      assert_select "input[name=?]", "review[rating]"

      assert_select "textarea[name=?]", "review[body]"

      assert_select "input[name=?]", "review[user_id]"

      assert_select "input[name=?]", "review[location_id]"
    end
  end
end
