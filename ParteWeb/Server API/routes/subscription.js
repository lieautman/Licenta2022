const express = require('express');
const router = express.Router();

const Subscription=require('../tableModels/subscription');

router.route('/').get(async(req,res,next)=>{
    try{
        res.status(200).json({message:'on subscription route'});
    }
    catch(err){
        next(err);
    }
});
router.route("/all").get(async (req, res, next) => {
  try {
    let subscriptions = await Subscription.findAll();
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
    const subscription = await Subscription.create(req.body);
    if (subscription) {
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
    const subscription = await Subscription.findByPk(req.params.id);
    if (subscription) {
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