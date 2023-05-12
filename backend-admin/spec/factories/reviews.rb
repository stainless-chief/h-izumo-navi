FactoryBot.define do
  factory :review do
    title { "MyString" }
    rating { 1 }
    body { "MyText" }
    user { nil }
    location { nil }
  end
end
