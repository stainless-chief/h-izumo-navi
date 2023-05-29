import { Controller } from "@hotwired/stimulus"
import axios from 'axios';

// Connects to data-controller="analitics"
export default class extends Controller {
  connect() {
    console.log('Connect to analitics')
  }
}
