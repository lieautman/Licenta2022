//account table structure
const Sequelize = require("sequelize");
const sequelize = require('../DB/DB_driver');
const { DataTypes } = require('sequelize');

const Account = sequelize.define('account',{
    idAccount: {
        type: DataTypes.UUID,
        defaultValue: DataTypes.UUIDV4,
        primaryKey: true
    }, 
    firstName:{
        type: Sequelize.STRING,
        allowNull:false,
        validate:{
            len:[3, 10]
        }
    },
    lastName:{
        type: Sequelize.STRING,
        allowNull:false
    },
    email:{
        type: Sequelize.STRING,
        allowNull:false,
        validate:{
            isEmail:true
        }
    },
    birthYear:{
        type: Sequelize.INTEGER,
        allowNull:false,
        validate:{
            min:1900
        }
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
    }
});

module.exports = Account;