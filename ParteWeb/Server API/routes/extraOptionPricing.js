const express = require('express');
const router = express.Router();

const moment = require('moment')

const ExtraOptionPricing=require('../tableModels/extraOptionPricing');
const Account=require('../tableModels/account');

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

router.route('/').get(async(req,res,next)=>{
    try{
        res.status(200).json({message:'on extraOptionPricing route'});
    }
    catch(err){
        next(err);
    }
});
router.route("/all").post(async (req, res, next) => {
  try {
    let extraOptionPricing = await ExtraOptionPricing.findAll();
    if (Array.isArray(extraOptionPricing)&&!extraOptionPricing.length) {
        res.status(404).json({ message: "No extraOptions!" });
    } else {
        res.status(200).json({ extraOptionPricing });
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

routerApp.route("/create").post(async (req, res, next) => {
  try {
    const extraOptionPricing = await ExtraOptionPricing.create(req.body);
    if (extraOptionPricing) {
      res.status(200).json({ message: "Created!"  });
    } else {
      res.status(404).json({ message: "Error on creation!" });
    }
  } catch (err) {
    next(err);
  }
});
routerApp.route("/update/:id").put(async (req, res, next) => {
  try {
    const extraOptionPricing = await ExtraOptionPricing.findByPk(req.params.id);
    if (extraOptionPricing) {
      const updatedExtraOptionPricing = await extraOptionPricing.update(req.body);
      res.status(200).json({message: "Updated!" });
    } else {
      res.status(404).json({ message: "There is no such extraOption!" });
    }
  } catch (err) {
    next(err);
  }
});

module.exports = router;