import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
  connect() {
    if (document.getElementById('location_latitude').value.length === 0) {
      var center = [ -0.228408, 51.58959 ] 
     }
     else {
       var center =[document.getElementById('location_longitude').value, document.getElementById('location_latitude').value]
     }
    mapboxgl.accessToken = 'pk.eyJ1IjoiY2hpZWYtc3MiLCJhIjoiY2xndGVkNnp3MTV0bjNkbWtzc25sdDlodiJ9.IigjwyBzw-Z_FdBd3eW1tg';
    const map = new mapboxgl.Map({
    container: 'map',
    style: 'mapbox://styles/mapbox/streets-v11',
    center: center,
    zoom: 13
    });

    const geocoder = new MapboxGeocoder({
      accessToken: mapboxgl.accessToken,
      mapboxgl: mapboxgl
  });

  document.getElementById('geocoder').appendChild(geocoder.onAdd(map));
  geocoder.on('result', function(e) {
    document.getElementById('location_title').value = e.result.location_title
    document.getElementById('location_longitude').value = e.result.center[0]
    document.getElementById('location_latitude').value = e.result.center[1]
    
    console.log(e.result)
    
    })
    
  }
}