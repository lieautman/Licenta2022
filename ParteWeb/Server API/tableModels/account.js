//account table structure
const Sequelize = require("sequelize");
const sequelize = require('../DB/DB_driver');
const { DataTypes } = require('sequelize');

const Account = sequelize.define('account',{
    idAccount: {
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
    username:{
        type: Sequelize.STRING,
        allowNull:false,
        unique:true
    },
    password:{
        type: Sequelize.STRING,
        allowNull:false
    },
    type:{
        type: Sequelize.STRING,
        allowNull:false
    },
    token:{
        type: Sequelize.STRING
    },
    expiery:{
        type:DataTypes.DATE
    }
});

module.exports = Account;