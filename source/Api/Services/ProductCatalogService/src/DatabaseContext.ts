import mongoose from 'mongoose';

mongoose.set('useCreateIndex', true);
const url:string = 'mongodb://localhost:27017/';
const user:string = 'root';
const password:string = 'root';

mongoose.Promise = global.Promise;
mongoose.connect(url, {
    useNewUrlParser: true,
    user: user,
    pass: password
}).then(() => {
    console.log('successfully connected to the database');
}).catch(err => {
    console.log('error connecting to the database');
    process.exit();
});
    
    export = mongoose.connection;