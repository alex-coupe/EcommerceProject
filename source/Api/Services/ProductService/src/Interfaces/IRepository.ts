export default interface IRepository<T>{
    GetAll(): Promise<T[]>;
    GetOne(slug: string):Promise<T>;
    Create(arg:T): T;
    Update(arg:T):T;
    Delete(slug: string):void;
    SaveChanges(item:T):Promise<T>;
}