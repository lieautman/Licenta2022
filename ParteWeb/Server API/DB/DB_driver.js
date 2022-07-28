const Sequelize = require("sequelize");
//database config
// const sequelize = new Sequelize({
//     dialect: 'sqlite',
//     storage: './DB/simple.db'
// });


const sequelize = new Sequelize({
    host: 'localhost',
    port: 5432,
    database: 'licenta',
    dialect: 'postgres',
    username: 'postgres',
    password: 'admin'
});


module.exports = sequelize;
