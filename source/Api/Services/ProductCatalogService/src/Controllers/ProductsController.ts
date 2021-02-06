import IProduct from '../Interfaces/IProduct';
import ProductRepository from '../Repositories/ProductRepository';

import express from 'express';
export default class ProductsController{
    _productRepository: ProductRepository
 
    constructor() {
       this._productRepository = new ProductRepository();
    }

    GetAll = async (req: express.Request, res: express.Response) => {
      const products:IProduct[] = await this._productRepository.GetAll();
      res.setHeader('Content-Type', 'application/json');
      res.statusCode = 200;
      res.json(products);
    };

    
    GetById = (req: express.Request, res: express.Response) => {
      res.setHeader('Content-Type', 'application/json');
      res.statusCode = 200;
      res.send(`Hello World from get by id:${req.params._id}`);
      res.end();
    };

    Create = (req: express.Request, res: express.Response) => {
      res.setHeader('Content-Type', 'application/json');
      res.statusCode = 200;
      res.send("Hello World from post");
      res.end();
    };

    Update = (req: express.Request, res: express.Response) => {
      res.setHeader('Content-Type', 'application/json');
      res.statusCode = 200;
      res.send("Hello World from put");
      res.end();
    };
    
    Delete = (req: express.Request, res: express.Response) => {
      res.setHeader('Content-Type', 'application/json');
      res.statusCode = 200;
      res.send(`Hello World from delete id:${req.params._id}`);
      res.end();
    };
}