# frozen_string_literal: true

# This file should contain all the record creation needed to seed the database with its default values.
# The data can then be loaded with the bin/rails db:seed command (or created alongside the database with db:setup).
#
# Examples:
#
#   movies = Movie.create([{ name: "Star Wars" }, { name: "Lord of the Rings" }])
#   Character.create(name: "Luke", movie: movies.first)

me = User.create!(email: 'roucke@mail.ru', 
  password: 'foobar')

3.times do |_i|
  user = User.create(email: Faker::Internet.email, password: 'foobar')
end

Location.create!(title: 'Idzumoshi temple',
 short_describtion: 'Izumo-taisha (出雲大社, "Izumo Grand Shrine"), officially Izumo Ōyashiro, is one of the most ancient and important Shinto shrines in Japan.',
 description: 'No record gives the date of establishment. Located in Izumo, Shimane Prefecture, it is home to two major festivals. It is dedicated to the god Ōkuninushi (大国主大神, Ōkuninushi no Ōkami), famous as the Shinto deity of marriage and to Kotoamatsukami, distinguishing heavenly kami. The shrine is believed by many to be the oldest Shinto shrine in Japan, even predating the Ise Grand Shrine.',
 address: '195 Kitsukihigashi',
 country: 'Japan',
 city: 'Idzumo',
 state: 'Shimane',
 image: 'backend-admin/app/assets/images/izumo_taisha.jpg',
 latitude: 35.401944,
 longitude: 132.685556,
 user: me)

Location.create!(title: 'Mankusen Jinja',
 short_describtion: 'This shrine conveys the myth that it is the last stop for the eight million gods who gather nationally to worship during the Shinto festival, held every October (old lunar calendar).',
 description: 'The gods that gather include, Kushimikenu-no-mikoto, Sukunahikona-no-mikoto, Oonamuchi-no-kami and Yaoyorozu-no-kami and visitors can receive various kinds of good fortune.',
 address: 'Hikawachouaikawa 258',
 country: 'Japan',
 city: 'Idzumo',
 state: 'Shimane',
 image: 'backend-admin/app/assets/images/jinja.jpeg',
 latitude: 35.383854577493786,
 longitude: 132.78870940097602,
 user: me)

Location.create!(title: 'Izumo Cultural Heritage Museum',
 short_describtion: 'In the case of Izumo Province, territorial authority was granted in 1638 to Matsudaira Naomasa, the grandson of shogun Tokugawa Ieyasu',
 description: 'Rule by the Matsudaira Clan as a cadet daimyō house, which enjoyed favorable relations with the Tokugawa shoguns, continued unbroken for over 230 years, until Japan’s feudal domains were abolished and replaced with modern prefectures. For this reason, a deep relationship was formed between the Matsudaira Clan of Matsue Domain and their subjects, one that has found expression in cultural as well as political and economic terms.',
 address: '520 Hamacho',
 country: 'Japan',
 city: 'Idzumo',
 state: 'Shimane',
 image: 'backend-admin/app/assets/images/museum.jpeg',
 latitude: 35.38204351395479,
 longitude: 132.7149068956665,
 user: me)

Location.create!(title: 'Mitoshisha',
 short_describtion: 'Kotoshironushi no Kami is the son of Okuninushi no Kami, a god who obeys when forced to hand over a country. He is currently a fishing-loving god who went to fish at Cape Miho in Izumo. Along with Hiruko, the first god born between Izanagi-no-mikoto and Izanami-no-mikoto, he is also considered Ebisu-sama',
 description: 'Toshigami is a deity that is installed in every home on the first day of the New Year as part of a private annual event. In some places they are called Ootoshikami or Toshitokujin, but depending on the place they are called New Year Gods, Echo Gods, etc. in ascending order. Because it is a deity associated with rice cultivation, it has been worshiped since ancient times, and even today, farmers and others still have a strong tradition of honoring this deity.',
 address: 'Taishacho Yokan',
 country: 'Japan',
 city: 'Idzumo',
 state: 'Shimane',
 image: 'mitoshisha.jpeg',
 latitude: 35.40410627120034,
 longitude: 132.70911524232892,
 user: me)

Location.create!(title: 'Kitayama Goro',
 short_describtion: 'March 27, 2021 Cloudy after good weather From Kitayama-Goro to Taisha Misen',
 description: 'Two years ago, Mr. Mishiro, a geoguide, climbed Kitayama-Goro, commonly known as 5 Yen Goro, which was first featured on FB. The actual object is larger than I imagined, with a diameter of 150 meters. Rhyolite rocks were stacked on top of each other at an inclination of 35 degrees. At the top of Mt. Misen, my mountain friends from Izumo City called me for the first time in two years, and my FB friends from Kurayoshi City spoke to me again, so it was an unexpectedly fun time. The descent from Hanazutsu Pass was difficult and it took time to find the route. It is better to choose the route along the left bank, as shown on the route diagram, with a large margin of time.',
 address: 'Taishacho Yokan',
 country: 'Japan',
 city: 'Idzumo',
 state: 'Shimane',
 image: 'backend-admin/app/assets/images/kitayama.jpeg',
 latitude: 35.40350440389999,
 longitude: 132.7095484740872,
 user: me)

Location.create!(title: 'Reizenji',
 short_describtion: 'A temple built in 1883 where roses bloom with prayers for world peace. Founded in 736, a temple where roses bloom with prayers for world peace. Yingshan Temple was founded in the 8th year of Tenpyos reign.',
 description: 'Tomio-no-sato, where Ryozen-ji Temple is located, is called "Tomi" in the Kojiki and "Torimi" in the Nihonshoki.
Since the time of Emperor Bidatsu, this region has belonged to the Ono family. Udaijin Ono Tomihito (said to be the son of Ono no Imoko, an envoy of the Sui Dynasty) participated in the Jinshin War, so in 672 he retired from his post and lived quietly in Tomiyama. From April 5, 12th year of Temmu (684), he visited Kumano Hongu for 21 days. During this time, he was inspired by Yakushi Nyorai to build a herbal bath on the mountain. And wealthy people were called Khan Taka Sennin and revered.',
 address: '1171 Taishacho Yokan',
 country: 'Japan',
 city: 'Idzumo',
 state: 'Shimane',
 image: 'backend-admin/app/assets/images/reizenji.jpeg',
 latitude: 35.3973826768007,
 longitude: 132.73697137908184,
 user: me)

Location.create!(title: 'Takahama Hachimangu',
 short_describtion: 'The origins of Sakurayama Hachimangu Shrine date from the time of the Emperor Nintoku (413 - 439), when he reguested Prince Takefurukuma-no-mikoto to subjugate the monster Ryoumen Sukuna, an incredible beast with 2 heads, 4 arms and 4 legs.',
 description: 'Before undertaking his task, the warrior enshrined his father, the Emperor Ojin as the deitty of this sanctuary, and prayed for the success of his missiuon.
In 1683, through the benefaction of Lord Kanamori, the shirine was enlarged and offcially established for the protection of the town.
More than 1,500,000 people vist the shirine annually.',
 address: '721 Yabicho',
 country: 'Japan',
 city: 'Idzumo',
 state: 'Shimane',
 image: 'backend-admin/app/assets/images/Takahama Hachimangu.jpeg',
 latitude: 35.399227035024985,
 longitude: 132.75115842196362,
 user: me)

Location.create!(title: 'Agata Jinja',
 short_describtion: 'Kotoshironushi no Kami is the son of Okuninushi no Kami, a god who obeys when forced to hand over a country. He is currently a fishing-loving god who went to fish at Cape Miho in Izumo. Along with Hiruko, the first god born between Izanagi-no-mikoto and Izanami-no-mikoto, he is also considered Ebisu-sama',
 description: 'Toshigami is a deity that is installed in every home on the first day of the New Year as part of a private annual event. In some places they are called Ootoshikami or Toshitokujin, but depending on the place they are called New Year Gods, Echo Gods, etc. in ascending order. Because it is a deity associated with rice cultivation, it has been worshiped since ancient times, and even today, farmers and others still have a strong tradition of honoring this deity.',
 address: 'Kunidomicho, 2',
 country: 'Japan',
 city: 'Idzumo',
 state: 'Shimane',
 image: 'backend-admin/app/assets/images/Agata_Jinja_Uji.jpg',
 latitude: 35.41840338636822,
 longitude: 132.79658558270904,
 user: me)

Location.create!(title: 'Kizuki Seaside Park',
 short_describtion: 'This Scenery of Kizuki Seaside Park photo can be used for personal projects. It can also be used for commercial projects in some cases.',
 description: 'This Scenery of Kizuki Seaside Park photo can be used for personal projects. It can also be used for commercial projects in some cases.',
 address: 'Taishacho Kizukinishi',
 country: 'Japan',
 city: 'Idzumo',
 state: 'Shimane',
 image: 'backend-admin/app/assets/images/kizuki.jpeg',
 latitude: 35.393215613138,
 longitude: 132.6743090451686,
 user: me)

Location.create!(title: 'Inasa Beach',
 short_describtion: 'Located on the coast to the west of Izumo Taisha, Inasa Beach is a spiritual spot with a mythical connection.',
 description: 'There is a small island known as Benten-jima, and a small shrine sits upon this rock. The white sandy beach forms a long and beautiful arc, and it has even been selected as one of Japan’s 100 great beaches. The view of the evening sun sinking behind the silhouette of Benten-jima is stunning, and as a symbol of “Izumo, sacred place of the setting sun,” it is even registered as a Japan Heritage Site. It is also the beach of the kamimukae-shinji ceremony held to welcome gods from throughout Japan. In addition, in summer, it is also popular as a swimming beach.',
 country: 'Japan',
 city: 'Idzumo',
 state: 'Shimane',
 image: 'backend-admin/app/assets/images/inasa beach.jpeg',
 latitude: 35.400646637880264,
 longitude: 132.67254118952482,
 user: me)