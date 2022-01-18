const INITIAL_STATE = {
    extraOptionPriceList:[],
    extraOptionList:[],
    fetching:false,
    fetched:false,
    message:null
}

export default function reducer (state = INITIAL_STATE,action){
    switch(action.type){

        case 'GET_EXTRAOPTION_PRICE_PENDING':
        case 'CREATE_EXTRAOPTION_PENDING':
        case 'GET_EXTRAOPTION_PENDING':
            return {...state,fetching:true,fetched:false}
        case 'GET_EXTRAOPTION_PRICE_FULFILLED':
            return {...state,extraOptionPriceList:action.payload.extraOptionPricing,fetching:false,fetched:true}
        case 'CREATE_EXTRAOPTION_FULFILLED':
            return {...state,message:action.payload.message,extraOptionList:action.payload.extraOptionList,fetching:false,fetched:false}
        case 'GET_EXTRAOPTION_FULFILLED':
            return {...state,extraOptionList:action.payload.extraOptions,fetching:false,fetched:false}
        case 'GET_EXTRAOPTION_PRICE_REJECTED':
        case 'CREATE_EXTRAOPTION_REJECTED':
        case 'GET_EXTRAOPTION_REJECTED':
            return {...state,message:action.payload.message,fetching:false,fetched:false}


        default:
            return {...state}
    }
}