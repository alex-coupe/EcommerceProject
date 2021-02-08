export default interface IRepository<T>{
    GetAll(category: string): Promise<T[]>;
    GetOne(slug: string):Promise<T>;
    CreateNew(item:T): Promise<T>;
    Update(arg:T):T;
    Delete(slug: string):void;
}