const express = require('express');
const router = express.Router();

//pt token
const moment = require('moment')
const TOKEN_TIMEOUT=3600

//algoritm de hashing - de implementat
const hash_sha256=(string)=>{
  return string;
}

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

router.route("/signup_web").post(async (req, res, next) => {
  try {
    //testare date nulle sau siruri vide
    if((req.body.firstName===''||
        req.body.lastName===''||
        req.body.email===''||
        req.body.birthYear===''||
        req.body.username===''||
        req.body.passwordHash===''||
        req.body.type==='')||(
        req.body.firstName===null||
        req.body.lastName===null||
        req.body.email===null||
        req.body.birthYear===null||
        req.body.username===null||
        req.body.password===null||
        req.body.type===null))
        res.status(400).json({message:"Introduceti toate campurile!"});
    else{
      //hash password for database
      const passwordHash = hash_sha256(req.body.password);
      
      //check if username is used
      const username = req.body.username;
      const user=await Account.findOne({where:{username:username}});
      if(user)
          res.status(409).json({message:"Username deja folosit!"});
      else{
        const account = await Account.create({
          "firstName":req.body.firstName,
          "lastName":req.body.lastName,
          "email":req.body.email,
          "birthYear":req.body.birthYear,
          "username":req.body.username,
          "password":passwordHash,
          "type":"client",
        });
        if (account) {
          res.status(200).json({ message: "Created!"  });
        } else {
          res.status(404).json({ message: "Error on creation!" });
        }
      }
    }
  } catch (err) {
    next(err);
  }
});
router.route("/login_web").post(async (req, res, next) => {
  try{
    const username = req.body.username;
    const password = req.body.password;
    const user = await Account.findOne({where:{username:username}});
    if(user){
        if(user.password===hash_sha256(password)){
            let token=Math.random().toString(36);
            let expiery=moment().add(TOKEN_TIMEOUT,'seconds');

            user.token=token;
            user.expiery=expiery;
            await user.save()
          

            res.status(201).json({
                id:user.idAccount,
                firstName:user.firstName,
                lastName:user.lastName,
                birthYear:user.birthYear,
                username:user.username,
                type:user.type,
                token:user.token
            });
        }
        else{
            res.status(401).json({message:'Parola incorecta!'});
        }
    }
    else{
        res.status(404).json({message:'Nu gasim utilizatorul!'});
    }
}
catch(err){
    next(err);
}
});

module.exports = router;