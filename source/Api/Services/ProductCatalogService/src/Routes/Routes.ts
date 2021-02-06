import express from 'express'
import ProductsController from '../Controllers/ProductsController';

var router = express.Router();
export default class Routes {
    private _productsController: ProductsController;
    
    constructor () {
        this._productsController = new ProductsController();   
    }
    get routes () {
        var controller = this._productsController;
        router.get("/api/v1/products", controller.GetAll);
        router.get("/api/v1/products/:_id", controller.GetById);
        router.post("/api/v1/products/", controller.Create);
        router.put("/api/v1/products/:_id", controller.Update);
        router.delete("/api/v1/products/:_id", controller.Delete);
        
        return router;
    }
}