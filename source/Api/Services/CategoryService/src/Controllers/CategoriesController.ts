import ICategory from '../Interfaces/ICategory';
import CategoryRepository from '../Repositories/CategoryRepository';
import express from 'express';

export default class CategoriesController{
    _categoryRepository: CategoryRepository
 
    constructor() {
       this._categoryRepository = new CategoryRepository();
    }

    GetAll = async (req: express.Request, res: express.Response) => {
      const categories:ICategory[] = await this._categoryRepository.GetAll();
      res.setHeader('Content-Type', 'application/json');
      res.statusCode = 200;
      res.json(categories);
    };

    
    GetBySlug = (req: express.Request, res: express.Response) => {
      res.setHeader('Content-Type', 'application/json');
      res.statusCode = 200;
      res.send(`Hello World from get by id:${req.params.slug}`);
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
      res.send(`Hello World from delete id:${req.params.slug}`);
      res.end();
    };
}