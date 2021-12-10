//module imports
const express = require('express');
//posibil sa le pun in alt fisier
const Sequelize = require("sequelize");
const sequelize = new Sequelize({
    dialect: 'sqlite',
    storage: './createDB/simple.db'
});

//constant imports
const PORT = require('./configuration/index').PORT_API;
//tables imports
const Account = require('./tableModels/account')(sequelize);
//routes imports
const accountRouter = require('./routes/account')(sequelize);


//start app
const app=express();

//routes
app.get('/',(req,res)=>{
    res.status(200).json({message:'Welcome to the API!'});
});

//router for accounts
app.use('/account',accountRouter);

//open server
app.listen(PORT,()=>{
    console.log(`API creat la portul ${PORT}`)
});