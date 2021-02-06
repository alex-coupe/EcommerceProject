import { Mongoose } from "mongoose";
import IProduct from "./IProduct";

export default interface IRepository<T>{
    GetAll(): Promise<T[]>;
    GetOne(id: number):Promise<T>;
    Create(arg:T): T;
    Update(arg:T):T;
    Delete(id: number):void;
    SaveChanges(item:IProduct):Promise<IProduct>;
}