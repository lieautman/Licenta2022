//subscription table structure
const Sequelize = require("sequelize");
const sequelize = require('../DB/DB_driver');
const { DataTypes } = require('sequelize');
const Subscription = sequelize.define('sim',{
        idSim: {
            type: DataTypes.UUID,
            defaultValue: DataTypes.UUIDV4,
            primaryKey: true
        },
        nrSerie:{
            type: DataTypes.INTEGER
        }
    });
module.exports = Subscription;