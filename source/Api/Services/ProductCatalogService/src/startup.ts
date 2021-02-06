import express from 'express';
import('./Models/ImageSchema');
import('./Models/CategorySchema');
import('./Models/ProductSchema');
import Routes from "./Routes/Routes";
import mongoose from 'mongoose';

const app = express();
mongoose.set('useCreateIndex', true);


try {
mongoose.connect('mongodb+srv://admin:admin@cluster0.al1l0.mongodb.net/test?retryWrites=true&w=majority',  { useNewUrlParser: true, useUnifiedTopology: true });
}
catch (error)
{
    console.log(error);
}

const db = mongoose.connection;
db.on('error', console.error.bind(console, 'connection error:'));

db.once('open', function() {
  console.log("connected to Mongo");
});
const port:number = 5000;

app.set("port", port);

const router = new Routes();

app.use('api/v1/products', router.routes);
app.get("/api/v1/products", (req,res) => {
    res.setHeader('Content-Type', 'application/json');
    res.statusCode = 200;
    res.send("Hello World");
    res.end();
});

app.listen(port, () => console.log(`Server started on port ${port}`));