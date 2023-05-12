require 'rails_helper'

RSpec.describe "reviews/show", type: :view do
  before(:each) do
    assign(:review, Review.create!(
      title: "Title",
      rating: 2,
      body: "MyText",
      user: nil,
      location: nil
    ))
  end

  it "renders attributes in <p>" do
    render
    expect(rendered).to match(/Title/)
    expect(rendered).to match(/2/)
    expect(rendered).to match(/MyText/)
    expect(rendered).to match(//)
    expect(rendered).to match(//)
  end
end
