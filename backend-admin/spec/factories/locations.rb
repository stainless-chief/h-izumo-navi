FactoryBot.define do
  factory :location do
    title { "MyString" }
    description { "MyText" }
    address { "MyString" }
    country { "MyString" }
    city { "MyString" }
    state { "MyString" }
    image { "MyString" }
    short_describtion { "MyText" }
    latitude { 1.5 }
    longitude { 1.5 }
    comment { "MyString" }
    user { nil }
  end
end
