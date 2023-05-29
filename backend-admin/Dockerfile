FROM ruby:3.2.0-alpine AS builder

RUN apk update -y && \
    apk add --no-install-recommends -y libpq-dev unzip \
    sudo libvips-dev libvips42 \
    imagemagick \
    imagemagick-dev \
    imagemagick-libs \
    postgresql-dev \
    build-base 

COPY Gemfile Gemfile.lock ./

RUN bundle install

FROM ruby:3.2.0-alpine AS runner

RUN apk update && \
    apk add --no-install-recommends -y tzdata \
    nodejs \
    postgresql-dev \
    gcompat

WORKDIR /app

COPY --from=builder /usr/local/bundle/ /usr/local/bundle/

COPY . .

EXPOSE 3000

CMD ["./bin/rails", "server"]