import { Console } from 'console';
import express from 'express';
import dotenv from 'dotenv';
import * as routes from "./Routes/Routes";

const app = express();
dotenv.config();

const port:number = parseInt(process.env.SERVER_PORT || "5000");

app.set("port", port);

app.listen(port, () => console.log(`Server started on port ${port}`));