const INITIAL_STATE = {
    subscriptionList:[],
    fetching:false,
    fetched:false,
    message:null
}

export default function reducer (state = INITIAL_STATE,action){
    switch(action.type){

        case 'CREATE_SUBSCRIPTION_PENDING':
        case 'GET_SUBSCRIPTION_PENDING':
            return{...state,fetching:true,fetched:true}
        case 'CREATE_SUBSCRIPTION_FULFILLED':
        case 'GET_SUBSCRIPTION_FULFILLED':
            return{...state,subscriptionList:action.payload.subscriptions,message:(action.payload!==undefined)?(action.payload.message!==undefined)?action.payload.message:"":"",fetching:true,fetched:true}
        case 'CREATE_SUBSCRIPTION_REJECTED':
        case 'GET_SUBSCRIPTION_REJECTED':
            return{...state,message:action.payload.message,fetching:true,fetched:false}

        default:
            return {...state}
    }
}