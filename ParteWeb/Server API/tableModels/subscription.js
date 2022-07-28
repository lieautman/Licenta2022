//subscription table structure
const Sequelize = require("sequelize");
const sequelize = require('../DB/DB_driver');
const { DataTypes } = require('sequelize');
const Subscription = sequelize.define('subscription',{
        idSubscription: {
            type: DataTypes.UUID,
            defaultValue: DataTypes.UUIDV4,
            primaryKey: true
        },
        dataStart:{
            type: Sequelize.STRING,
            allowNull:false
        },
        reccuring:{
            type: DataTypes.STRING,
            allowNull:false
        },
        idSimAsociat: {
            type: DataTypes.UUID,
        },
        idClient: {
            type: DataTypes.UUID,
            allowNull:false
        },
        idSubscriptionType: {
            type: DataTypes.UUID,
            allowNull:false
        }
    });
module.exports = Subscription;