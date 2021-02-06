import mongoose, {Schema} from 'mongoose';
import ICategory from '../Interfaces/ICategory';

const CategorySchema: Schema = new Schema({
    Main: {type: String, required: true, unique: true},
    SubCategories: {type: [String] , required: false}
});

export default mongoose.model<ICategory>('Category', CategorySchema);