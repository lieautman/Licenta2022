//client table structure
const Sequelize = require("sequelize");
const sequelize = require('../DB/DB_driver');
const { DataTypes } = require('sequelize');

const Client = sequelize.define('client',{
    idClient: {
        type: DataTypes.UUID,
        defaultValue: DataTypes.UUIDV4,
        primaryKey: true,
        allowNull:false
    }, 
    firstName:{
        type: Sequelize.STRING,
        allowNull:false,
    },
    lastName:{
        type: Sequelize.STRING,
        allowNull:false
    },
    email:{
        type: Sequelize.STRING,
        allowNull:false,
    },
    birthYear:{
        type: Sequelize.INTEGER,
        allowNull:false,
    },
    paymentMethod:{
        type: Sequelize.ENUM('cash', 'transfer'),
        allowNull:false,
    },
    idAccount: {
        type: Sequelize.DataTypes.UUID
    }
});

module.exports = Client;