const express = require('express');
const router = express.Router();

const ExtraOption=require('../tableModels/extraOption');

router.route('/').get(async(req,res,next)=>{
    try{
        res.status(200).json({message:'on extraOption route'});
    }
    catch(err){
        next(err);
    }
});
router.route("/all").get(async (req, res, next) => {
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
    const extraOption = await ExtraOption.create(req.body);
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

module.exports = router;