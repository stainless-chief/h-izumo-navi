require 'rails_helper'

RSpec.describe "tours/edit", type: :view do
  let(:tour) {
    Tour.create!(
      name: "MyString",
      description: "MyText"
    )
  }

  before(:each) do
    assign(:tour, tour)
  end

  it "renders the edit tour form" do
    render

    assert_select "form[action=?][method=?]", tour_path(tour), "post" do

      assert_select "input[name=?]", "tour[name]"

      assert_select "textarea[name=?]", "tour[description]"
    end
  end
end
