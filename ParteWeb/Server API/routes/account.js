const express = require('express');
const router = express.Router();

module.exports=(sequelize)=>{
    router.get('/',(req,res,next)=>{
        console.log('sunt pe ruta de conturi');
        res.status(200).json({message:'sunt pe ruta de conturi'});
    });

    return router;
}