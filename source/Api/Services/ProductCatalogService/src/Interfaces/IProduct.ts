import {Document} from 'mongoose';
import ICategory from './ICategory';
import IImage from './IImage';


export default interface IProduct extends Document {
    Name: string;
    Sku: string;
    Description: string;
    Price: number;
    Slug: string;
    Image: IImage;
    Category: ICategory; 
}