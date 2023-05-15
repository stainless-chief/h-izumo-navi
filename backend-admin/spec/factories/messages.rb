FactoryBot.define do
  factory :message do
    user { nil }
    room { nil }
    body { "MyText" }
  end
end
