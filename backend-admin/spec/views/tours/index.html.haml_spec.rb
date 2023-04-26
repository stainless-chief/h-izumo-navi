require 'rails_helper'

RSpec.describe "tours/index", type: :view do
  before(:each) do
    assign(:tours, [
      Tour.create!(
        title: "Title"
      ),
      Tour.create!(
        title: "Title"
      )
    ])
  end

  it "renders a list of tours" do
    render
    cell_selector = Rails::VERSION::STRING >= '7' ? 'div>p' : 'tr>td'
    assert_select cell_selector, text: Regexp.new("Title".to_s), count: 2
  end
end
