import IProduct from '../Interfaces/IProduct';
import IRepository from '../Interfaces/IRepository';
import Product from '../Models/ProductSchema';

export default class ProductRepository implements IRepository<IProduct>
{
     GetAll(): Promise<IProduct[]> {
        return Product.collection.find().toArray();
    }
    GetOne(slug: string): Promise<IProduct> {
        throw new Error('Method not implemented.');
    }
    Create(arg: IProduct): IProduct {
        throw new Error('Method not implemented.');
    }
    Update(arg: IProduct): IProduct {
        throw new Error('Method not implemented.');
    }
    Delete(slug: string): void {
        throw new Error('Method not implemented.');
    }
    SaveChanges(item:IProduct): Promise<IProduct> {
        return item.save();
    }
    
    
}
