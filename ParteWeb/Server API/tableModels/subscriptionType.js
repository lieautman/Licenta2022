//subscriptionType table structure
const Sequelize = require("sequelize");
const sequelize = require('../DB/DB_driver');
const { DataTypes } = require('sequelize');
const SubscriptionType = sequelize.define('subscriptionType',{
    idSubscriptionType: {
        type: DataTypes.UUID,
        defaultValue: DataTypes.UUIDV4,
        primaryKey: true
    },
    nrMessages:{
        type: Sequelize.INTEGER,
        allowNull:false
    },
    nrMinutes:{
        type: Sequelize.INTEGER,
        allowNull:false
    },
    nrGbInternet:{
        type: Sequelize.INTEGER,
        allowNull:false
    },
    price:{
        type: Sequelize.INTEGER,
        allowNull:false
    }
});
module.exports=SubscriptionType;