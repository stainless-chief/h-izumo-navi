FROM ruby:3.2.0-alpine

RUN apk update && apk upgrade

RUN apk add --no-cache file libpq-dev unzip \
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

RUN apk add tzdata \
    nodejs \
    gcompat \
		ruby-dev \
		ruby-irb

RUN gem install rdoc \
		ruby-vips 

WORKDIR /app

COPY . .

EXPOSE 3000

CMD ["./bin/rails", "server"]