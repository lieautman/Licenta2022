//employess table structure
const Sequelize = require("sequelize");
module.exports=(sequelize)=>{

    return sequelize.define('accounts',{
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
        username:{
            type: Sequelize.STRING,
            allowNull:false,
            unique:true
        },
        passwordHash:{
            type: Sequelize.STRING,
            allowNull:false
        },
        birthYear:{
            type: Sequelize.INTEGER,
            allowNull:false,
            validate:{
                min:1900
            }
        }
    });
}