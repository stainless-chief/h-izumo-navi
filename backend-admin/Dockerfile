FROM ruby:3.2.0-alpine AS builder

RUN apk add\
    build-base \
    postgresql-dev \
    glib-2.0 \
    gmodule-2.0 \
    gobject-2.0

RUN apk add imagemagick imagemagick-dev imagemagick-libs

COPY Gemfile* .
RUN bundle install

ARG MAGICK_VERSION=7.0.8-64
ARG MAGICK_URL=https://github.com/ImageMagick/ImageMagick/archive

RUN wget ${MAGICK_URL}/${MAGICK_VERSION}.tar.gz \
	&& tar xf ${MAGICK_VERSION}.tar.gz \
	&& cd ImageMagick-${MAGICK_VERSION} \
	&& ./configure \
	&& make V=0 \
	&& make install 

ARG VIPS_VERSION=8.8.3
ARG VIPS_URL=https://github.com/libvips/libvips/releases/download

RUN wget ${VIPS_URL}/v${VIPS_VERSION}/vips-${VIPS_VERSION}.tar.gz \
	&& tar xf vips-${VIPS_VERSION}.tar.gz \
	&& cd vips-${VIPS_VERSION} \
	&& ./configure \
	&& make V=0 \
	&& make install 

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