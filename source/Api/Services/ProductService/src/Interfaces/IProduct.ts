import {Document} from 'mongoose';

export default interface IProduct extends Document {
    Name: string;
    Sku: string;
    Description: string;
    Price: number;
    Slug: string;
    ImagePath: string;
    ImageAltText: string,
    Category: string, 
    SubCategories: string[]
}