import mongoose, {Schema} from 'mongoose';
import IProduct from '../Interfaces/IProduct';

const ProductSchema: Schema = new Schema({
        Name: {type: String, required: true},
        Sku: {type: String, required: true, unique: true},
        Description: {type: String, required: true, minlength: 30},
        Price: {type: Number, required: true},
        Slug: {type: String, required: true, unique: true},
        ImagePath: {type: String, required: true},
        ImageAltText: {type: String, required: true},
        Category: {type: String, required: true}, 
        SubCategories: {type: [String], required: true}
});

export default mongoose.model<IProduct>('Product', ProductSchema);