import IProduct from '../Interfaces/IProduct';
import Product from '../Models/ProductSchema'
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

    
    GetById = (id:number) => {

    };

    Create = (entity: typeof Product) => {

    };

    Update = (entity: typeof Product) => {

    };
    
    Delete = (id: number) => {

    };
}