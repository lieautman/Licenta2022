const Sequelize = require("sequelize");
const sequelize = require('./DB/DB_driver')

//list of all tables
const Account = require('./tableModels/account');
const Client = require('./tableModels/client');
const ExtraOption = require('./tableModels/extraOption');
const Subscription = require('./tableModels/subscription');
const SubscriptionType = require('./tableModels/subscriptionType');

sequelize.sync({force:true})//alter:true
    .then(()=>{
        console.log('Database synced');
    })
    .catch((err)=>{
        console.warn(err);
    });