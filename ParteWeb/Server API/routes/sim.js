const express = require('express');
const router = express.Router();

const moment = require('moment')

const Sim=require('../tableModels/sim');


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
        res.status(200).json({message:'on sim route'});
    }
    catch(err){
        next(err);
    }
});
router.route("/all").post(async (req, res, next) => {
  try {
    let sims = await Sim.findAll();
    if (Array.isArray(sims)&&!sims.length) {
        res.status(404).json({ message: "No subscriptions!" });
    } else {
        res.status(200).json({ sims });
    }
  } catch (err) {
    next(err);
  }
});
router.route("/create").post(async (req, res, next) => {
  try {
    const sim = await Sim.create(req.body);
    if (sim) {
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
    const sim = await Sim.findByPk(req.params.id);
    if (sim) {
      const updatedSim = await sim.update(req.body);
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
    const sim = await Sim.findByPk(req.params.id);
    if (sim) {
      const deletedSim = await sim.destroy();
      res.status(200).json({message: "Erased!" });
    } else {
      res.status(404).json({ message: "There is no such subscription!" });
    }
  } catch (err) {
    next(err);
  }
});

module.exports = router;