import mongoose, {Schema} from 'mongoose';
import IImage from '../Interfaces/IImage';

const ImageSchema: Schema = new Schema({
    FilePath: {type: String, required: true},
    AltText: {type: String, required: true}
});

export default mongoose.model<IImage>('Image', ImageSchema);