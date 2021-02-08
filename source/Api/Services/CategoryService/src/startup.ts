import express from 'express';
import('./Models/CategorySchema');
import context from './DatabaseContext';
import CategoriesController from './Controllers/CategoriesController';


const app = express();
const db = context;

db.on('error', console.error.bind(console, 'connection error:'));

db.once('open', function() {
  console.log("connected to Mongo");
});
const port:number = 5002;

app.set("port", port);

const _categoriesController = new CategoriesController();

app.get("/api/v1/categories",  _categoriesController.GetAll);

app.get("/api/v1/categories/:slug", _categoriesController.GetBySlug);

app.post("/api/v1/categories", _categoriesController.Create);

app.put("/api/v1/categories/:slug", _categoriesController.Update);

app.delete("/api/v1/categories/:slug", _categoriesController.Delete);
