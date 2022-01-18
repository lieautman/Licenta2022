const express = require('express');
const router = express.Router();

const moment = require('moment')

const ExtraOption=require('../tableModels/extraOption');
const Account=require('../tableModels/account');
const ExtraOptionPricing=require('../tableModels/extraOptionPricing');


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
        res.status(200).json({message:'on extraOption route'});
    }
    catch(err){
        next(err);
    }
});
router.route("/all").post(async (req, res, next) => {
  try {
    let extraOptions = await ExtraOption.findAll();
    if (Array.isArray(extraOptions)&&!extraOptions.length) {
        res.status(404).json({ message: "No extraOptions!" });
    } else {
        res.status(200).json({ extraOptions });
    }
  } catch (err) {
    next(err);
  }
});
router.route("/create").post(async (req, res, next) => {
  try {
    const idSubscription=req.body.idSubscription
    const type=req.body.type
    const number=req.body.number
    const extraOptionPricing = await ExtraOptionPricing.findAll({where:{
      type:type
    }});
    const pricePerUnit = extraOptionPricing[0].dataValues.pricePerUnit
    const price=pricePerUnit*number;
    const extraOption = await ExtraOption.create({idSubscription:idSubscription,type:type,number:number,price:price});
    if (extraOption) {
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
    const extraOption = await ExtraOption.findByPk(req.params.id);
    if (extraOption) {
      const updatedExtraOption = await extraOption.update(req.body);
      res.status(200).json({message: "Updated!" });
    } else {
      res.status(404).json({ message: "There is no such extraOption!" });
    }
  } catch (err) {
    next(err);
  }
});
router.route("/delete/:id").delete(async (req, res, next) => {
  try {
    const extraOption = await ExtraOption.findByPk(req.params.id);
    if (extraOption) {
      const deletedExtraOption = await extraOption.destroy();
      res.status(200).json({message: "Erased!" });
    } else {
      res.status(404).json({ message: "There is no such extraOption!" });
    }
  } catch (err) {
    next(err);
  }
});

router.route("/allForSubscription").post(async (req, res, next) => {
  try {
    let extraOptions = await ExtraOption.findAll({where:{
      idSubscription:req.body.idSubscription
    }});
    if (Array.isArray(extraOptions)&&!extraOptions.length) {
        res.status(404).json({ message: "No extraOptions!" });
    } else {
        res.status(200).json({ extraOptions });
    }
  } catch (err) {
    next(err);
  }
});

module.exports = router;