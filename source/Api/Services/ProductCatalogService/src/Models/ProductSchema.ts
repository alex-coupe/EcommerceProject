import mongoose, {Schema} from 'mongoose';
import IProduct from '../Interfaces/IProduct';
import {ImageSchema} from '../Models/ImageSchema';
import {CategorySchema} from '../Models/CategorySchema';

const ProductSchema: Schema = new Schema({
        Name: {type: String, required: true},
        Sku: {type: String, required: true, unique: true},
        Description: {type: String, required: true, minlength: 30},
        Price: {type: Number, required: true},
        Slug: {type: String, required: true, unique: true},
        Categories:CategorySchema,
        Image: ImageSchema   
});

export default mongoose.model<IProduct>('Product', ProductSchema);