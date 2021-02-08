import express from 'express';
import('./Models/ProductSchema');
import context from './DatabaseContext';
import ProductsController from './Controllers/ProductsController';

const app = express();
const db = context;

db.on('error', console.error.bind(console, 'connection error:'));

db.once('open', function() {
  console.log("connected to Mongo");
});
const port:number = 5001;

app.set("port", port);

const _productsController = new ProductsController();


//Products Routes

app.get("/api/v1/products/:slug", _productsController.GetBySlug);

app.get("/api/v1/categoryproducts/:category", _productsController.GetByCategory);

app.post("/api/v1/products", _productsController.Create);

app.put("/api/v1/products/:slug", _productsController.Update);

app.delete("/api/v1/products/:id", _productsController.Delete);
