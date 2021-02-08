import express from 'express';
import('./Models/ImageSchema');
import context from './DatabaseContext';

import ImagesController from './Controllers/ImagesController';

const app = express();
const db = context;

db.on('error', console.error.bind(console, 'connection error:'));

db.once('open', function() {
  console.log("connected to Mongo");
});
const port:number = 5008;

app.set("port", port);


const _imagesController = new ImagesController();

//Images Routes

app.get("/api/v1/images",  _imagesController.GetAll);

app.get("/api/v1/images/:slug", _imagesController.GetBySlug);

app.post("/api/v1/images", _imagesController.Create);

app.delete("/api/v1/_imagesController/:slug", _imagesController.Delete);

app.listen(port, () => console.log(`Server started on port ${port}`));