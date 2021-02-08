import {Document} from 'mongoose';

export default interface IImage extends Document {
    FilePath: string;
    AltText: string;
}