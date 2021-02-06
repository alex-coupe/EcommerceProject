import mongoose from 'mongoose';

mongoose.set('useCreateIndex', true);

try {
    mongoose.connect('mongodb+srv://admin:admin@cluster0.al1l0.mongodb.net/test?retryWrites=true&w=majority',  { useNewUrlParser: true, useUnifiedTopology: true });
    }
    catch (error)
    {
        console.log(error);
    }
    
    export = mongoose.connection;