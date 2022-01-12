const INITIAL_STATE = {
    page:'Login',
    id:'',
    firstName:'',
    lastName:'',
    birthYear:'',
    username:'',
    type:'',
    token:'',
    fetching:false,
    fetched:false,
    message:null
}

export default function reducer (state = INITIAL_STATE,action){
    switch(action.type){
        case 'Go_Login':
            return {...state,page:'Login',message:null,id:'',firstName:'',lastName:'',birthYear:'',username:'',type:'',token:''}
        case 'Go_Signup':
            return {...state,page:'Signup',message:null}

            
        case 'Signup_PENDING':
            return{...state,fetching:true,fetched:false}
        case 'Signup_FULFILLED':
            return{...state,message:action.payload.message,fetching:true,fetched:true}
        case 'Signup_REJECTED':
            return{...state,message:action.payload.message,fetching:true,fetched:false}

        case 'Login_PENDING':
            return{...state,fetching:true,fetched:false}
        case 'Login_FULFILLED':
            return{...state,page:action.payload.page,id:action.payload.id,firstName:action.payload.firstName,lastName:action.payload.lastName,birthYear:action.payload.birthYear,username:action.payload.username,type:action.payload.type,token:action.payload.token,fetching:true,fetched:true,message:action.payload.message}
        case 'Login_REJECTED':
            return{...state,message:action.payload.message,fetching:true,fetched:false}
    
        default:
            return {...state}
    }
}