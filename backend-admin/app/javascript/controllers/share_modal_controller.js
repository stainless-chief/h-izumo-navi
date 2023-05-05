import { Controller } from "@hotwired/stimulus"

// Connects to data-controller="share-modal"
export default class extends Controller {
  copyLink() {
    navigator.clipboard.writeText(this.element.dataset.shareUrl).then(() => {
      alert("Copied to clipboard");
    });
  }
  shareWhatsapp(){
    navigator.clipboard.writeText(this.element.dataset.shareUrl).then(() => {
      window.open(`whatsapp://send?text=${this.element.dataset.shareUrl}`)
    });
  }
  shareFacebook(){
    navigator.clipboard.writeText(this.element.dataset.shareUrl).then(() => {
      window.open(`facebook://send?text=${this.element.dataset.shareUrl}`)
    });
  }
  shareLine(){
    navigator.clipboard.writeText(this.element.dataset.shareUrl).then(() => {
      window.open(`line://send?text=${this.element.dataset.shareUrl}`)
    });
  }
}
