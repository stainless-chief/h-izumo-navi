import { Controller } from '@hotwired/stimulus'
import axios from 'axios';

export default class extends Controller {
  HEADERS = { 'ACCEPT': 'application/json' };

  favorite(e) {
    e.preventDefault();
    if (this.element.dataset.favorited === 'true') {
      this.unfavoriteLocation();
    } else {
      this.favoriteLocation();
    }
  }

  getFavoritePath() {
    return '/api/favorites';
  }

  getUnfavoritePath(favoriteId) {
    return `/api/favorites/${favoriteId}`
  }

  favoriteLocation() {
    axios.post(this.getFavoritePath(), {
      user_id: this.element.dataset.userId,
      location_id: this.element.dataset.locationId
    }, {
      headers: this.HEADERS
    })
    .then((response) => {
      this.element.dataset.favorited = 'true'
      this.element.dataset.favoriteId = response.data.id;
      this.element.classList.add("fa-beat");
      this.element.setAttribute("style", "color: red");
      this.element.localStorage.setProperty("style", "color: red");
    });
  }

  unfavoriteLocation() {
    axios.delete(this.getUnfavoritePath(this.element.dataset.favoriteId), {
      headers: this.HEADERS
    }).then((response) => {
      this.element.dataset.favorited = 'false'
      this.element.dataset.favoriteId = '';
      this.element.classList.remove("fa-beat");
      this.element.removeAttribute("style", "color: red");
      this.element.localStorage.removeProperty("style", "color: red");
    });
  }
}