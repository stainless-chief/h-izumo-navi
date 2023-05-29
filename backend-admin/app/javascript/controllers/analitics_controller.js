import { Controller } from "@hotwired/stimulus"
import axios from 'axios';

// Connects to data-controller="analitics"
export default class extends Controller {
  connect() {
    console.log('Connect to analitics')
  }
  HEADERS = { 'ACCEPT': 'application/json' };

  getAnaliticsPath() {
    return '/http://localhost:5223/analytics/v1.0/save';
  }

send_analitics() {
  axios.post(this.getAnaliticsPath(), {
    user_id: this.element.dataset.userId,
    product_id: this.element.dataset.locationId
  }, {
    headers: this.HEADERS
  })
  .then((response) => {
    this.element.dataset.sendedAnalitics = 'true'
    this.element.dataset.sendAnaliticsId = response.data.id;
    this.element.dataset.latitude = 'location_latitude';
    this.element.dataset.longitude = 'location_longitude';
    this.element.dataset.sendAnalitics.createdAt;
    if(review.rating >=3) {
      this.element.dataset.emotion = 100;
    }else{
      this.element.dataset.emotion = -100;
    }
  });
}
}