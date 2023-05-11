FactoryBot.define do
  factory :review do
    title { "MyString" }
    body { "MyText" }
    rating { 1 }
    user { nil }
    location { nil }
  end
end
