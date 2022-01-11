const express = require('express');
const router = express.Router();

const moment = require('moment')

const SubscriptionType=require('../tableModels/subscriptionType');
const Account=require('../tableModels/account');

//token usage middleware
router.use(async(req,res,next)=>{
  let token = req.body.token
  console.log(token)
  try{
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
        res.status(200).json({message:'on subscriptionType route'});
    }
    catch(err){
        next(err);
    }
});
router.route("/all").post(async (req, res, next) => {
  try {
    let subscriptionType = await SubscriptionType.findAll();
    if (Array.isArray(subscriptionType)&&!subscriptionType.length) {
        res.status(404).json({ message: "No subscriptionType!" });
    } else {
        res.status(200).json({ subscriptionType });
    }
  } catch (err) {
    next(err);
  }
});
router.route("/create").post(async (req, res, next) => {
  try {
    const subscriptionType = await SubscriptionType.create(req.body);
    if (subscriptionType) {
      res.status(200).json({ message: "Created!"  });
    } else {
      res.status(404).json({ message: "Error on creation!" });
    }
  } catch (err) {
    next(err);
  }
});
router.route("/update/:id").put(async (req, res, next) => {
  try {
    const subscriptionType = await SubscriptionType.findByPk(req.params.id);
    if (subscriptionType) {
      const updatedSubscriptionType = await subscriptionType.update(req.body);
      res.status(200).json({message: "Updated!" });
    } else {
      res.status(404).json({ message: "There is no such subscriptionType!" });
    }
  } catch (err) {
    next(err);
  }
});
router.route("/delete/:id").delete(async (req, res, next) => {
  try {
    const subscriptionType = await SubscriptionType.findByPk(req.params.id);
    if (subscriptionType) {
      const deletedSubscriptionType = await subscriptionType.destroy();
      res.status(200).json({message: "Erased!" });
    } else {
      res.status(404).json({ message: "There is no such subscriptionType!" });
    }
  } catch (err) {
    next(err);
  }
});

module.exports = router;