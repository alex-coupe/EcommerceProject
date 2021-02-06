import { Model, Mongoose } from 'mongoose';
import IProduct from '../Interfaces/IProduct';
import IRepository from '../Interfaces/IRepository';
import Product from '../Models/ProductSchema';

export default class ProductRepository implements IRepository<IProduct>
{
     GetAll(): Promise<IProduct[]> {
        return Product.collection.find().toArray();
    }
    GetOne(id: number): Promise<IProduct> {
        throw new Error('Method not implemented.');
    }
    Create(arg: IProduct): IProduct {
        throw new Error('Method not implemented.');
    }
    Update(arg: IProduct): IProduct {
        throw new Error('Method not implemented.');
    }
    Delete(id: number): void {
        throw new Error('Method not implemented.');
    }
    SaveChanges(item:IProduct): Promise<IProduct> {
        return item.save();
    }
    
    
}
