//extraOption table structure
const Sequelize = require("sequelize");
const sequelize = require('../DB/DB_driver');
const { DataTypes } = require('sequelize');
const ExtraOption =  sequelize.define('extraOption',{
    idExtraOption: {
        type: DataTypes.UUID,
        defaultValue: DataTypes.UUIDV4,
        primaryKey: true
    },
    idSubscription: {
        type: DataTypes.UUID,
        allowNull:false
    },
    type:{
        type: Sequelize.STRING,
        allowNull:false
    },
    price:{
        type: Sequelize.INTEGER,
        allowNull:false
    }
});
module.exports = ExtraOption;