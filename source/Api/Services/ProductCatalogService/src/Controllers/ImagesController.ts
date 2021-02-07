import IImage from '../Interfaces/IImage';
import ImageRepository from '../Repositories/ImageRepository';
import express from 'express';

export default class ImagesController{
    _imageRepository: ImageRepository
 
    constructor() {
       this._imageRepository = new ImageRepository();
    }

    GetAll = async (req: express.Request, res: express.Response) => {
      const images:IImage[] = await this._imageRepository.GetAll();
      res.setHeader('Content-Type', 'application/json');
      res.statusCode = 200;
      res.json(images);
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