require 'rails_helper'

RSpec.describe "tours/show", type: :view do
  before(:each) do
    assign(:tour, Tour.create!(
      title: "Title"
    ))
  end

  it "renders attributes in <p>" do
    render
    expect(rendered).to match(/Title/)
  end
end
