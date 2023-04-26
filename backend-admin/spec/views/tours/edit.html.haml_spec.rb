require 'rails_helper'

RSpec.describe "tours/edit", type: :view do
  let(:tour) {
    Tour.create!(
      title: "MyString"
    )
  }

  before(:each) do
    assign(:tour, tour)
  end

  it "renders the edit tour form" do
    render

    assert_select "form[action=?][method=?]", tour_path(tour), "post" do

      assert_select "input[name=?]", "tour[title]"
    end
  end
end
