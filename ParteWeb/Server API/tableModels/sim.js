//subscription table structure
const Sequelize = require("sequelize");
const sequelize = require('../DB/DB_driver');
const { DataTypes } = require('sequelize');
const Sim = sequelize.define('sim',{
        idSim: {
            type: DataTypes.UUID,
            defaultValue: DataTypes.UUIDV4,
            primaryKey: true
        },
        nrSerie:{
            type: DataTypes.INTEGER,
            allowNull:false
        }
    });
module.exports = Sim;