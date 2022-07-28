const express = require('express');
const router = express.Router();

const moment = require('moment')

const Client=require('../tableModels/client');
const Account=require('../tableModels/account');

const Subscription=require('../tableModels/subscription');
const ExtraOption=require('../tableModels/extraOption');

//token usage middleware
router.use(async(req,res,next)=>{
  let token = req.body.token
  try{
    console.log(req.body.paymentMethod)
    const user = await Account.findOne({
      where:{
        token:token
      }
    })
    if(user){
      if(moment().diff(user.expiery,'seconds')<0){
        next()
      }
      else{
        res.status(401).json({message:'Token expirat!'})
      }
    }
    else{
      res.status(401).json({message:'Neautorizat!'})
    }
  }
  catch(err){
    next(err)
  }
});

router.route('/').get(async(req,res,next)=>{
    try{
        res.status(200).json({message:'on client route'});
    }
    catch(err){
        next(err);
    }
});
router.route("/all").post(async (req, res, next) => {
  try {
    let client = await Client.findAll();
    if (Array.isArray(client)&&!client.length) {
        res.status(404).json({ message: "No clients!" });
    } else {
        res.status(200).json({ client });
    }
  } catch (err) {
    next(err);
  }
});
router.route("/create").post(async (req, res, next) => {
  try {
    if(req.body.paymentMethod!=='cash'&&req.body.paymentMethod!=='transfer'){
      res.status(404).json({ message: "Error on creation!" });
    }
    else{
      //testare date nulle sau siruri vide
      if((req.body.firstName===''||
          req.body.lastName===''||
          req.body.email===''||
          req.body.birthYear===''||
          req.body.paymentMethod==='')
          ||
          (req.body.firstName===null||
          req.body.lastName===null||
          req.body.email===null||
          req.body.birthYear===null||
          req.body.paymentMethod===null)){
        res.status(400).json({message:"Introduceti toate campurile!"});
      }
      else{
        const client = await Client.create({
          "firstName":req.body.firstName,
          "lastName":req.body.lastName,
          "email":req.body.email,
          "birthYear":req.body.birthYear,
          "paymentMethod":req.body.paymentMethod
        });

        if (client) {
          res.status(200).json({ message: "Created!"  });
        } else {
          res.status(404).json({ message: "Error on creation!" });
        }
      }
    }
  } catch (err) {
    next(err);
  }
});

const routerApp = express.Router();
router.use('/',routerApp);
routerApp.use(async(req,res,next)=>{
  let token = req.body.token
  try{
    let user = await Account.findOne({
      where:{
        type:"manager",
        token:token
      }
    })
    if(!user){
      user = await Account.findOne({
        where:{
          type:"admin",
          token:token
        }
      })
    }
    if(user){
      if(moment().diff(user.expiery,'seconds')<0){
        next();
      }
      else{
        res.status(401).json({message:'Token expirat!'})
      }
    }
    else{
      res.status(401).json({message:'Neautorizat!'})
    }
  }
  catch(err){
    next(err)
  }
});

routerApp.route("/delete/:id").post(async (req, res, next) => {
  try {
    const client = await Client.findByPk(req.params.id);

    //stergere cont client
    const account = await Account.findOne({where:{
      idAccount:client.idAccount
    }});
    if (account)
      account.destroy();

    const subscriptions = await Subscription.findAll({where:{
      idClient:client.idClient
    }});
    subscriptions.forEach(async(subscription) => {
      const extraOptions = await ExtraOption.findAll({where:{
        idSubscription:subscription.idSubscription
      }});
      extraOptions.forEach(async(extraOption) => {
        await extraOption.destroy();
      });
      await subscription.destroy();
    });

    if (client) {
      const deletedClient = await client.destroy();
      res.status(200).json({message: "Erased!" });
    } else {
      res.status(404).json({ message: "There is no such client!" });
    }
  } catch (err) {
    next(err);
  }
});

module.exports = router;