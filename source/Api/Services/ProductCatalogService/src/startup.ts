import express from 'express';
import('./Models/ImageSchema');
import('./Models/ProductSchema');
import context from './DatabaseContext';
import ProductsController from './Controllers/ProductsController';
import ImagesController from './Controllers/ImagesController';

const app = express();
const db = context;

db.on('error', console.error.bind(console, 'connection error:'));

db.once('open', function() {
  console.log("connected to Mongo");
});
const port:number = 5001;

app.set("port", port);

const _productsController = new ProductsController();
const _imagesController = new ImagesController();

//Products Routes
app.get("/api/v1/products",  _productsController.GetAll);

app.get("/api/v1/products/:slug", _productsController.GetBySlug);

app.get("/api/v1/categoryproducts/:category", _productsController.GetByCategory);

app.post("/api/v1/products", _productsController.Create);

app.put("/api/v1/products/:slug", _productsController.Update);

app.delete("/api/v1/products/:id", _productsController.Delete);



//Images Routes

app.get("/api/v1/images",  _imagesController.GetAll);

app.get("/api/v1/images/:slug", _imagesController.GetBySlug);

app.post("/api/v1/images", _imagesController.Create);

app.delete("/api/v1/_imagesController/:slug", _imagesController.Delete);

app.listen(port, () => console.log(`Server started on port ${port}`));