FROM ruby:3.2.0-alpine AS builder

RUN apk add \
    build-base \
    postgresql-dev

RUN apk add -y --no-install-recommends libvips42

RUN apk add imagemagick imagemagick-dev imagemagick-libs

COPY Gemfile Gemfile.lock ./

RUN bundle install

FROM ruby:3.2.0-alpine AS runner

RUN apk add \
    tzdata \
    nodejs \
    postgresql-dev \
    gcompat
WORKDIR /app

COPY --from=builder /usr/local/bundle/ /usr/local/bundle/

COPY . .

EXPOSE 3000

CMD ["./bin/rails", "server"]