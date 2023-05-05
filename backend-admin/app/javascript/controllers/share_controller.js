import { Controller } from "@hotwired/stimulus"

// Connects to data-controller="share"
export default class extends Controller {
  share(e) {
    e.preventDefault();

    document.getElementById('share-modal-trigger').click();
  }
}
