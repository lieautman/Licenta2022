//subscription table structure
const Sequelize = require("sequelize");
const sequelize = require('../DB/DB_driver');
const { DataTypes } = require('sequelize');
const { default: ModelManager } = require("sequelize/dist/lib/model-manager");
const Subscription = sequelize.define('subscriptionType',{
        idSubscription: {
            type: DataTypes.UUID,
            defaultValue: DataTypes.UUIDV4,
            primaryKey: true
        },
        idSubscriptionType: {
            type: DataTypes.UUID,
            defaultValue:0
        }
    });
module.exports = Subscription;