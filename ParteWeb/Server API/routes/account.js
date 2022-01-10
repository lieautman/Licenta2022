const express = require('express');
const router = express.Router();

const Account=require('../tableModels/account');

router.route('/').get(async(req,res,next)=>{
    try{
        res.status(200).json({message:'on account route'});
    }
    catch(err){
        next(err);
    }
});
router.route("/all").get(async (req, res, next) => {
  try {
    let accounts = await Account.findAll();
    if (Array.isArray(accounts)&&!accounts.length) {
        res.status(404).json({ message: "No accounts!" });
    } else {
        res.status(200).json({ accounts });
    }
  } catch (err) {
    next(err);
  }
});
router.route("/create").post(async (req, res, next) => {
  try {
    const account = await Account.create(req.body);
    if (account) {
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
    const account = await Account.findByPk(req.params.id);
    if (account) {
      const updatedAccount = await account.update(req.body);
      res.status(200).json({message: "Updated!" });
    } else {
      res.status(404).json({ message: "There is no such account!" });
    }
  } catch (err) {
    next(err);
  }
});
router.route("/delete/:id").delete(async (req, res, next) => {
  try {
    const account = await Account.findByPk(req.params.id);
    if (account) {
      const deletedAccount = await account.destroy();
      res.status(200).json({message: "Erased!" });
    } else {
      res.status(404).json({ message: "There is no such account!" });
    }
  } catch (err) {
    next(err);
  }
});

module.exports = router;