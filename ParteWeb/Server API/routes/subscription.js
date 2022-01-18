const express = require('express');
const router = express.Router();

const moment = require('moment')

const Subscription=require('../tableModels/subscription');
const Account=require('../tableModels/account');
const SubscriptionType=require('../tableModels/subscriptionType');
const ExtraOption=require('../tableModels/extraOption');

let currentUser=null;

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
      idAccount:currentUser.idAccount
    }});
    //console.log(subscriptions)
    const extraOptions = await ExtraOption.findAll();
    //console.log(extraOptions)
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
router.route("/update/:id").put(async (req, res, next) => {
  try {
    const subscription = await Subscription.findByPk(req.params.id);
    if (subscription&&subscription.idAccount===currentUser.idAccount) {
      const updatedSubscription = await subscription.update(req.body);
      res.status(200).json({message: "Updated!" });
    } else {
      res.status(404).json({ message: "There is no such subscription!" });
    }
  } catch (err) {
    next(err);
  }
});
router.route("/delete/:id").delete(async (req, res, next) => {
  try {
    const subscription = await Subscription.findByPk(req.params.id);
    if (subscription&&subscription.idAccount===currentUser.idAccount) {
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