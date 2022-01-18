const Sequelize = require("sequelize");
const sequelize = require('./DB/DB_driver')

//list of all tables
const Account = require('./tableModels/account');
const ExtraOption = require('./tableModels/extraOption');
const ExtraOptionPricing = require('./tableModels/extraOptionPricing');
const Sim = require('./tableModels/sim');
const Subscription = require('./tableModels/subscription');
const SubscriptionType = require('./tableModels/subscriptionType');

sequelize.sync({force:true})//alter:true
    .then(()=>{
        console.log('Database synced');
    })
    .catch((err)=>{
        console.warn(err);
    });