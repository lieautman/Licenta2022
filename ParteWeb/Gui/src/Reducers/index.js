import{combineReducers}from 'redux'

import main from './main-reducers'
import subscriptionType from './subscriptionType-reducers'
import subscription from './subscription-reducers'
import extraOption from './extra-optiune'



export default combineReducers({
   main,
   subscriptionType,
   subscription,
   extraOption
})