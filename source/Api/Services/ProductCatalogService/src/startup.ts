import express from 'express';
import('./Models/ImageSchema');
import('./Models/CategorySchema');
import('./Models/ProductSchema');
import context from './DatabaseContext';
import ProductsController from './Controllers/ProductsController';

const app = express();
const db = context;

db.on('error', console.error.bind(console, 'connection error:'));

db.once('open', function() {
  console.log("connected to Mongo");
});
const port:number = 5000;

app.set("port", port);
const controller = new ProductsController();

app.get("/api/v1/products",  controller.GetAll);

app.get("/api/v1/products/:_id", controller.GetById);

app.post("/api/v1/products/", controller.Create);

app.put("/api/v1/products/:_id", controller.Update);

app.delete("/api/v1/products/:_id", controller.Delete);

app.listen(port, () => console.log(`Server started on port ${port}`));