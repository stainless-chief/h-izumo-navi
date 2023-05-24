# Pin npm packages by running ./bin/importmap

pin 'application', preload: true
pin '@hotwired/turbo-rails', to: 'turbo.min.js', preload: true
pin '@hotwired/stimulus', to: 'stimulus.min.js', preload: true
pin '@hotwired/stimulus-loading', to: 'stimulus-loading.js', preload: true
pin 'mapkick/bundle', to: 'mapkick.bundle.js'
pin_all_from 'app/javascript/controllers', under: 'controllers'
pin 'stimulus-rails-nested-form', to: 'https://ga.jspm.io/npm:stimulus-rails-nested-form@4.1.0/dist/stimulus-rails-nested-form.mjs'
pin 'axios', to: 'https://cdn.skypack.dev/axios@1.2.0'
pin '#lib/adapters/http.js', to: 'https://ga.jspm.io/npm:@jspm/core@2.0.0-beta.27/nodelibs/@empty.js'
pin '#lib/defaults/env/FormData.js', to: 'https://ga.jspm.io/npm:axios@0.27.2/lib/helpers/null.js'
pin '#lib/platform/node/index.js', to: 'https://ga.jspm.io/npm:@jspm/core@2.0.0-beta.27/nodelibs/@empty.js'
pin 'form-data', to: 'https://ga.jspm.io/npm:form-data@4.0.0/lib/browser.js'
pin '@rails/actioncable', to: 'actioncable.esm.js'
pin_all_from 'app/javascript/channels', under: 'channels'
pin 'stimulus-use', to: 'https://ga.jspm.io/npm:stimulus-use@0.41.0/dist/index.js'
pin 'hotkeys-js', to: 'https://ga.jspm.io/npm:hotkeys-js@3.8.7/dist/hotkeys.esm.js'
pin 'stimulus', to: 'https://ga.jspm.io/npm:stimulus@2.0.0/dist/stimulus.umd.js'
pin '@rails/activestorage', to: 'activestorage.esm.js'
pin 'chartkick', to: 'chartkick.js'
pin 'Chart.bundle', to: 'Chart.bundle.js'
