const Sequelize = require("sequelize");

const sequelize = new Sequelize({
    dialect: 'sqlite',
    storage: './simple.db'
});


const Account = require('../tableModels/account')(sequelize);

sequelize.sync({force:true})//alter:true
    .then(()=>{
        console.log('tables created');
    })
    .catch((err)=>{
        console.warn(err);
    });