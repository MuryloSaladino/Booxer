FROM node:18

WORKDIR /app

COPY Booxer.Web/UI/package.json Booxer.Web/UI/package-lock.json ./

RUN npm install

COPY Booxer.Web/UI/ ./

EXPOSE 4200

CMD ["npm", "start", "--", "--host", "0.0.0.0"]
