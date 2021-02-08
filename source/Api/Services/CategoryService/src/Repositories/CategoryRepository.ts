import ICategory from '../Interfaces/ICategory';
import IRepository from '../Interfaces/IRepository';
import Category from '../Models/CategorySchema';

export default class CategoryRepository implements IRepository<ICategory>
{
     GetAll(): Promise<ICategory[]> {
        return Category.collection.find().toArray();
    }
    GetOne(slug: string): Promise<ICategory> {
        throw new Error('Method not implemented.');
    }
    Create(arg: ICategory): ICategory {
        throw new Error('Method not implemented.');
    }
    Update(arg: ICategory): ICategory {
        throw new Error('Method not implemented.');
    }
    Delete(slug: string): void {
        throw new Error('Method not implemented.');
    }
    SaveChanges(item:ICategory): Promise<ICategory> {
        return item.save();
    }
}