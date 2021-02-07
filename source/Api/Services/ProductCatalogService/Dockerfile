FROM node:14
WORKDIR /usr/src/app
COPY package.json .
RUN npm install
ADD . /usr/src/app
RUN npm run build
EXPOSE 5001
CMD [ "node", "./build/startup.js" ]