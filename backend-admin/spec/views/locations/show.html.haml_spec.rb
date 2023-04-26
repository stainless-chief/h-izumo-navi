require 'rails_helper'

RSpec.describe "locations/show", type: :view do
  before(:each) do
    assign(:location, Location.create!(
      title: "Title",
      short_discription: "Short Discription",
      discription: "Discription",
      address: "Address",
      city: "City",
      state: "State",
      country: "Country",
      image: "Image"
    ))
  end

  it "renders attributes in <p>" do
    render
    expect(rendered).to match(/Title/)
    expect(rendered).to match(/Short Discription/)
    expect(rendered).to match(/Discription/)
    expect(rendered).to match(/Address/)
    expect(rendered).to match(/City/)
    expect(rendered).to match(/State/)
    expect(rendered).to match(/Country/)
    expect(rendered).to match(/Image/)
  end
end
