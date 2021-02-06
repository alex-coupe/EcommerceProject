import {Document} from 'mongoose';

export default interface ICategory extends Document {
    Main: string;
    SubCategories: string[]
}