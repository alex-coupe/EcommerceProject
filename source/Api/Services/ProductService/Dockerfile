FROM node:14
WORKDIR /usr/src/app
COPY ./Services/ProductCatalogService/package*.json ./
RUN npm install
COPY ./Services/ProductCatalogService/ .
CMD [ "npm", "start" ]
