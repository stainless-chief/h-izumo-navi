FROM ruby:3.2.0-alpine AS builder

RUN apk update && \
    apk add --no-cache file libpq-dev unzip \
    imagemagick \
    imagemagick-libs \
    postgresql-dev \
    build-base \
    autoconf \
		automake \
		libtool \
		zlib-dev \
		expat-dev \
		jpeg-dev \
		tiff-dev \
		glib-dev \
		libjpeg-turbo-dev \
		libexif-dev \
		lcms2-dev \
		fftw-dev \
		giflib-dev \
		libpng-dev \
		libwebp-dev \
		libgsf-dev 

COPY Gemfile Gemfile.lock ./

RUN bundle install

RUN apk update && apk upgrade


RUN apk add \
		ruby-dev \
		ruby-irb

RUN gem install rdoc \
		ruby-vips 

FROM ruby:3.2.0-alpine AS runner

RUN apk update && \
    apk add tzdata \
    nodejs \
    postgresql-dev \
    gcompat

WORKDIR /app

COPY --from=builder /usr/local/bundle/ /usr/local/bundle/

COPY . .

EXPOSE 3000

CMD ["./bin/rails", "server"]