import express from 'express';
import dotenv from 'dotenv';
import('./Models/ImageSchema');
import('./Models/CategorySchema');
import('./Models/ProductSchema');
import context from './DatabaseContext';
import ProductsController from './Controllers/ProductsController';
import CategoriesController from './Controllers/CategoriesController';
import ImagesController from './Controllers/ImagesController';

const app = express();
const db = context;
dotenv.config();

db.on('error', console.error.bind(console, 'connection error:'));

db.once('open', function() {
  console.log("connected to Mongo");
});
const port:number = parseInt(process.env.SERVER_PORT!) || 5000;

app.set("port", port);

const _productsController = new ProductsController();
const _categoriesController = new CategoriesController();
const _imagesController = new ImagesController();

//Products Routes
app.get("/api/v1/products",  _productsController.GetAll);

app.get("/api/v1/products/:slug", _productsController.GetBySlug);

app.post("/api/v1/products", _productsController.Create);

app.put("/api/v1/products/:slug", _productsController.Update);

app.delete("/api/v1/products/:id", _productsController.Delete);

//Categories Routes
app.get("/api/v1/categories",  _categoriesController.GetAll);

app.get("/api/v1/categories/:slug", _categoriesController.GetBySlug);

app.post("/api/v1/categories", _categoriesController.Create);

app.put("/api/v1/categories/:slug", _categoriesController.Update);

app.delete("/api/v1/categories/:slug", _categoriesController.Delete);

//Images Routes

//Categories Routes
app.get("/api/v1/images",  _imagesController.GetAll);

app.get("/api/v1/images/:slug", _imagesController.GetBySlug);

app.post("/api/v1/images", _imagesController.Create);

app.delete("/api/v1/_imagesController/:slug", _imagesController.Delete);

app.listen(port, () => console.log(`Server started on port ${port}`));