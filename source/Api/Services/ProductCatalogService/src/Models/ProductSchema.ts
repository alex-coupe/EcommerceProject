import mongoose, {Schema} from 'mongoose';
import IProduct from '../Interfaces/IProduct';
import CategorySchema from './CategorySchema';
import ImageSchema from './ImageSchema';

const ProductSchema: Schema = new Schema({
        Name: {type: String, required: true},
        Sku: {type: String, required: true, unique: true},
        Description: {type: String, required: true, minlength: 30},
        Price: {type: Number, required: true},
        Slug: {type: String, required: true, unique: true},
        Category: CategorySchema,
        Image: ImageSchema     
});

export default mongoose.model<IProduct>('Product', ProductSchema);