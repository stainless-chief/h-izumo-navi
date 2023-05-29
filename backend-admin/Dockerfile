FROM ruby:3.2.0-alpine AS builder

RUN apk update && \
    apk add libpq-dev unzip \
    imagemagick \
    imagemagick-dev \
    imagemagick-libs \
    postgresql-dev \
    build-base 

COPY Gemfile Gemfile.lock ./

RUN bundle install

ARG VIPS_VERSION=8.9.1
ARG VIPS_URL=https://github.com/libvips/libvips/releases/download

RUN apk update && apk upgrade

RUN wget -O- ${VIPS_URL}/v${VIPS_VERSION}/vips-${VIPS_VERSION}.tar.gz | tar xzC /tmp
RUN cd /tmp/vips-${VIPS_VERSION} \
	&& ./configure --prefix=/usr --disable-static --disable-debug \
	&& make V=0 \
	&& make install 

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