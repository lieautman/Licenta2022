const express = require('express');
const router = express.Router();

const moment = require('moment')

const Subscription=require('../tableModels/subscription');
const ExtraOption=require('../tableModels/extraOption');
const Account=require('../tableModels/account');
const Client=require('../tableModels/client');
const SubscriptionType=require('../tableModels/subscriptionType');

let currentUser=null;
let currentClient=null;

//adaugare data la care abonamentul incepe si una la care abonamentul expira
//adaugare sim

//token usage middleware
router.use(async(req,res,next)=>{
  let token = req.body.token
  try{
    const user = await Account.findOne({
      where:{
        token:token
      }
    })
    if(user){
      if(moment().diff(user.expiery,'seconds')<0){
        currentUser=user;
        const client = await Client.findOne({
          where:{
            idAccount:user.idAccount
          }
        })
        currentClient=client;
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
        res.status(200).json({message:'on subscription route'});
    }
    catch(err){
        next(err);
    }
});
router.route("/all").post(async (req, res, next) => {
  try {
    const subscriptions = await Subscription.findAll({where:{
      idClient:currentClient.idClient
    }});
    if (Array.isArray(subscriptions)&&!subscriptions.length) {
        res.status(404).json({ message: "No subscriptions!" });
    } else {
        res.status(200).json({ subscriptions });
    }
  } catch (err) {
    next(err);
  }
});
router.route("/allApp").post(async (req, res, next) => {
  try {
    const subscriptions = await Subscription.findAll({where:{
      idClient:req.body.idClient
    }});
    if (Array.isArray(subscriptions)&&!subscriptions.length) {
        res.status(404).json({ message: "No subscriptions!" });
    } else {
        res.status(200).json({ subscriptions });
    }
  } catch (err) {
    next(err);
  }
});
router.route("/create").post(async (req, res, next) => {
  try {
    let idSubscriptionTypeLocal=req.body.idSubscriptionType

    const subscriptionType = await SubscriptionType.findOne({where:{
      idSubscriptionType:idSubscriptionTypeLocal
    }})
    let dataStart=req.body.dataStart;
    var today = new Date(); 
    var date = today.getFullYear()+'-'+(today.getMonth()+1)+'-'+today.getDate();
    var dataStartFormatDate=new Date(dataStart);

    if(dataStart===null||dataStartFormatDate<today){
      req.body.dataStart=date.toString()
    }

      if(subscriptionType){
      const subscription = await Subscription.create(req.body);
      if (subscription) {
        res.status(200).json({ message: "Created!"  });
      } else {
        res.status(404).json({ message: "Error on creation!" });
      }
    }
    else{
      res.status(404).json({ message: "No subscription type with that id!" });
    }
  } catch (err) {
    next(err);
  }
});
router.route("/delete/:id").delete(async (req, res, next) => {
  try {
    const subscription = await Subscription.findByPk(req.params.id);

    const extraOptions = await ExtraOption.findAll({where:{
      idSubscription:subscription.idSubscription
    }});
    extraOptions.forEach(async(extraOption) => {
      await extraOption.destroy();
    });


    if (subscription&&subscription.idClient===currentClient.idClient) {
      const deletedSubscription = await subscription.destroy();
      res.status(200).json({message: "Erased!" });
    } else {
      res.status(404).json({ message: "There is no such subscription!" });
    }
  } catch (err) {
    next(err);
  }
});
router.route("/update/:id").put(async (req, res, next) => {
  try {
    const subscription = await Subscription.findByPk(req.params.id);
    if (subscription&&subscription.idClient===currentClient.idClient) {
      const updatedSubscription = await subscription.update(req.body);
      res.status(200).json({message: "Updated!" });
    } else {
      res.status(404).json({ message: "There is no such subscription!" });
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


routerApp.route("/deleteApp/:id").post(async (req, res, next) => {
  try {
    const subscription = await Subscription.findByPk(req.params.id);

    const extraOptions = await ExtraOption.findAll({where:{
      idSubscription:subscription.idSubscription
    }});
    extraOptions.forEach(async(extraOption) => {
      await extraOption.destroy();
    });


    if (subscription) {
      const deletedSubscription = await subscription.destroy();
      res.status(200).json({message: "Erased!" });
    } else {
      res.status(404).json({ message: "There is no such subscription!" });
    }
  } catch (err) {
    next(err);
  }
});

module.exports = router;