//extraOptionPricing table structure
const Sequelize = require("sequelize");
const sequelize = require('../DB/DB_driver');
const { DataTypes } = require('sequelize');
const ExtraOption =  sequelize.define('extraOptionPricing',{
    idExtraOptionPricing: {
        type: DataTypes.UUID,
        defaultValue: DataTypes.UUIDV4,
        primaryKey: true
    },
    type: {
        type: DataTypes.STRING,
        allowNull:false
    },
    pricePerUnit:{
        type: Sequelize.INTEGER,
        allowNull:false
    }
});
module.exports = ExtraOption;