# STAGE 1: Build
FROM node:14-alpine AS build
WORKDIR /app
COPY package.json ./
RUN npm install --only=prod
COPY . /app

RUN npm run build

# STAGE 2: add nginx
FROM nginx:stable-alpine

# Nginx config
COPY conf/nginx.conf /etc/nginx/conf.d/default.conf

COPY --from=build /app/build /usr/share/nginx/html
EXPOSE 80

# Copy .env file and shell script to container
WORKDIR /usr/share/nginx/html
COPY ./env.sh .
COPY .env .

# Make our shell script executable
RUN chmod +x env.sh

# Start Nginx server
CMD ["/bin/sh", "-c", "/usr/share/nginx/html/env.sh && nginx -g \"daemon off;\""]