FROM node:14
WORKDIR /usr/src/app
COPY ./Services/ImageService/package*.json ./
RUN npm install
COPY ./Services/ImageService/ .
CMD [ "npm", "start" ]
