import IImage from '../Interfaces/IImage';
import IRepository from '../Interfaces/IRepository';
import Image from '../Models/CategorySchema';

export default class ImageRepository implements IRepository<IImage>
{
     GetAll(): Promise<IImage[]> {
        return Image.collection.find().toArray();
    }
    GetOne(slug: string): Promise<IImage> {
        throw new Error('Method not implemented.');
    }
    Create(arg: IImage): IImage {
        throw new Error('Method not implemented.');
    }
    Update(arg: IImage): IImage {
        throw new Error('Method not implemented.');
    }
    Delete(slug: string): void {
        throw new Error('Method not implemented.');
    }
    SaveChanges(item:IImage): Promise<IImage> {
        return item.save();
    }
}