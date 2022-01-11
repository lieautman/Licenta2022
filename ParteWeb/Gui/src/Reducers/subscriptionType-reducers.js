const INITIAL_STATE = {
    subscriptionTypeList:[],
    fetching:false,
    fetched:false,
    message:null
}

export default function reducer (state = INITIAL_STATE,action){
    switch(action.type){

        case 'CREATE_SUBSCRIPTIONTYPE_PENDING':
        case 'GET_SUBSCRIPTIONTYPE_PENDING':
            return{...state,fetching:true,fetched:true}
        case 'CREATE_SUBSCRIPTIONTYPE_FULFILLED':
        case 'GET_SUBSCRIPTIONTYPE_FULFILLED':
            return{...state,subscriptionTypeList:action.payload.subscriptionType,fetching:true,fetched:true}
        case 'CREATE_SUBSCRIPTIONTYPE_REJECTED':
        case 'GET_SUBSCRIPTIONTYPE_REJECTED':
            return{...state,message:action.payload.message,fetching:true,fetched:false}

        default:
            return {...state}
    }
}