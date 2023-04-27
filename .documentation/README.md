# Problem
Track tourists across the city.

# Solution
![Service](https://raw.githubusercontent.com/ChiefNoir/h-izumo-navi/master/.documentation/promise_smal.png)
## Multi-source tracking system
Many single-purpose services will seek and collect available information about people's locations from a specific source.

All data will be stored for future analysis.
With collected data, we can build a heatmap of the city and map it to the actual map.
![Example map](https://raw.githubusercontent.com/ChiefNoir/h-izumo-navi/master/.documentation/example_map.png)

### Examples of the tracking services
> !! Only some services will be implemented for the prototype 
1. (*) Scan social networks (like Twitter, and Instagram) for posts with related locations;
2. (*) Place QR codes at the points of interest to provide help and collect data
3. Place [iBeacons](https://developer.apple.com/ibeacon/) at places of interest to provide help and collect data;
4. Place public WiFi hotspots to collect data;
5. (*) Create a service to provide help with navigating through the city and collect data;
6. Place surveillance cameras at the points of interest to analyze video-feed; 
7. Arrange a contract with mobile operators to receive data about the geo-position of the phones in the area;
8. Arrange a contract with hotels to collect information about the number of guests;
9. Arrange a contract with a taxi service to place geo-tracking devices into their's cars;
10. Arrange a contract with a car rental service to place geo-tracking devices into their's cars;

With a wide range of data-collector services, we can build a general heatmap of the city and find the "hot" spots where people generally go.

Also, heatmap analytics crossed with general points of interest (like, shrines, museums, etc) can help find "cold" places, which may be interesting for people, but for some reason, they are not going (troubles with public transport, or navigation, or lack of marketing).

And, collected big data can be used in any other way.

## Izumo navigator
> !! Service #5 ^
Let us introduce to you our service which provides information for all touristic points and showplaces. It will help you to find route to interesting places, to know it's history and share it with your friends. First, when you enter the site, you can see list of all places, and list of more favorites routes. When you login, you can create your oun route. After that you can share it with friends, discuss and gather them.

Also you can like, add to favorite, choose route you like which was created by another tourist.

Skills: eRuby language 3.2, template engine haml, rails 7 stimulus