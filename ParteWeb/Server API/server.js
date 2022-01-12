//module imports
const express = require('express');
const cors = require('cors');
const bodyParser = require('body-parser');

//constant imports
const PORT = require('./configuration/index').PORT_API;

//start app
const app=express();
app.use(cors());
app.use(bodyParser.json());

//router for accounts
app.use('/account',require('./routes/account'));
//router for clients
app.use('/client',require('./routes/client'));
//router for extraOptions
app.use('/extraOption',require('./routes/extraOption'));
//router for sim
app.use('/subscription',require('./routes/sim'));
//router for sbuscriptions
app.use('/subscription',require('./routes/subscription'));
//router for subscriptionTypes
app.use('/subscriptionType',require('./routes/subscriptionType'));

//modelarea erorilor
app.use((err, req, res, next) => {
    console.error(`[ERROR]: ${err}`);
    res.status(500).json({message:err.name});
  });

//open server
app.listen(PORT,()=>{
    console.log(`API creat la portul ${PORT}`)
});