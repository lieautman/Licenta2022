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
        idSimAsociat: {
            type: DataTypes.UUID,
        },
        idAccount: {
            type: DataTypes.UUID
        },
        idSubscriptionType: {
            type: DataTypes.UUID,
            defaultValue:0
        }
    });
module.exports = Subscription;