import IProduct from '../Interfaces/IProduct';
import ProductRepository from '../Repositories/ProductRepository';

import express from 'express';
export default class ProductsController{
    _productRepository: ProductRepository
 
    constructor() {
       this._productRepository = new ProductRepository();
    }

    GetByCategory = async (req: express.Request, res: express.Response) => {
      const products:IProduct[] = await this._productRepository.GetAll(req.params.category);
      res.setHeader('Content-Type', 'application/json');
      res.statusCode = 200;
      res.json(products);
    };

    
    GetBySlug = async (req: express.Request, res: express.Response) => {
      const product:IProduct = await this._productRepository.GetOne(req.params.slug);
      res.setHeader('Content-Type', 'application/json');
      res.statusCode = 200;
      res.json(product);
    };

    Create = async (req: express.Request, res: express.Response) => {
      const product = await this._productRepository.CreateNew(req.body);
      res.setHeader('Content-Type', 'application/json');
      res.statusCode = 200;
      res.send("Hello World from post");
      res.json(product);
    };

    Update = (req: express.Request, res: express.Response) => {
      res.setHeader('Content-Type', 'application/json');
      res.statusCode = 200;
      res.send("Route Not Implemented");
      res.end();
    };
    
    Delete = (req: express.Request, res: express.Response) => {
      res.setHeader('Content-Type', 'application/json');
      res.statusCode = 200;
      res.send(`Route Not Implemented`);
      res.end();
    };
}