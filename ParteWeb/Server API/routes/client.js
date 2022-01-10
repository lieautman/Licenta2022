const express = require('express');
const router = express.Router();

const Client=require('../tableModels/Client');

router.route('/').get(async(req,res,next)=>{
    try{
        res.status(200).json({message:'on client route'});
    }
    catch(err){
        next(err);
    }
});
router.route("/all").get(async (req, res, next) => {
  try {
    let clients = await Client.findAll();
    if (Array.isArray(clients)&&!clients.length) {
        res.status(404).json({ message: "No clients!" });
    } else {
        res.status(200).json({ clients });
    }
  } catch (err) {
    next(err);
  }
});
router.route("/create").post(async (req, res, next) => {
  try {
    const client = await Client.create(req.body);
    if (client) {
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
    const client = await Client.findByPk(req.params.id);
    if (client) {
      const updatedClient = await client.update(req.body);
      res.status(200).json({message: "Updated!" });
    } else {
      res.status(404).json({ message: "There is no such client!" });
    }
  } catch (err) {
    next(err);
  }
});
router.route("/delete/:id").delete(async (req, res, next) => {
  try {
    const client = await Client.findByPk(req.params.id);
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