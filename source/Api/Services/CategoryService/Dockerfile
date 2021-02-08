FROM node:14
WORKDIR /usr/src/app
COPY ./Services/CategoryService/package*.json ./
RUN npm install
COPY ./Services/CategoryService/ .
CMD [ "npm", "start" ]