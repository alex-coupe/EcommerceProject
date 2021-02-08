import IProduct from '../Interfaces/IProduct';
import IRepository from '../Interfaces/IRepository';
import Product from '../Models/ProductSchema';

export default class ProductRepository implements IRepository<IProduct>
{
     GetAll(category:string): Promise<IProduct[]> {
        return Product.collection.find({SubCategory : category }).toArray();
    }
    GetOne(slug: string): Promise<IProduct> {
        return Product.collection.findOne({Slug : slug });
    }
    CreateNew(item: IProduct): Promise<IProduct> {
        return item.save();
    }
    Update(arg: IProduct): IProduct {
        throw new Error('Method not implemented.');
    }
    Delete(slug: string): void {
        throw new Error('Method not implemented.');
    }    
}
