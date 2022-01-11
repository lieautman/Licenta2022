//subscription table structure
const Sequelize = require("sequelize");
const sequelize = require('../DB/DB_driver');
const { DataTypes } = require('sequelize');
const { default: ModelManager } = require("sequelize/dist/lib/model-manager");
const Subscription = sequelize.define('subscription',{
        idSubscription: {
            type: DataTypes.UUID,
            defaultValue: DataTypes.UUIDV4,
            primaryKey: true
        },
        idClient: {
            type: DataTypes.UUID,
            defaultValue:0
        },
        idSubscriptionType: {
            type: DataTypes.UUID,
            defaultValue:0
        }
    });
module.exports = Subscription;