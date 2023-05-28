FROM ruby:3.2.0-alpine AS builder

RUN apk add\
    build-base \
    postgresql-dev

RUN apk add imagemagick imagemagick-dev imagemagick-libs

COPY Gemfile* .
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
CMD ["rails", "server", "-b", "0.0.0.0"]