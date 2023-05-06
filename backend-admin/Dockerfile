FROM ruby:3.2.0-alpine3.17

ENV BUNDLER_VERSION=2.4.1

RUN apk add --update yarn build-base nodejs tzdata postgresql-dev postgresql-client libxslt-dev libxml2-dev imagemagick

ENV INSTALL_PATH /app_name
RUN mkdir -p $INSTALL_PATH

WORKDIR $INSTALL_PATH

COPY Gemfile Gemfile.lock ./

ARG RAILS_ENV
ENV RACK_ENV=$RAILS_ENV

RUN gem install bundler

RUN if [[ "$RAILS_ENV" == "production" ]]; then bundle install --without development test; else bundle install; fi

COPY yarn.lock ./

RUN yarn install --check-files

COPY . ./

CMD ["bundle", "exec", "rails", "s"]
