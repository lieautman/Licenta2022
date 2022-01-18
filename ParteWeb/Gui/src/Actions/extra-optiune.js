import {SERVER_GLOBAL}from'../Configs/globals'
const SERVER = SERVER_GLOBAL

export const CREATE_EXTRAOPTION_PRICE='CREATE_EXTRAOPTION_PRICE';
export const GET_EXTRAOPTION_PRICE='GET_EXTRAOPTION_PRICE';
export const CREATE_EXTRAOPTION='CREATE_EXTRAOPTION';
export const GET_EXTRAOPTION='GET_EXTRAOPTION';

export function createExtraOptionPrice(type,pricePerUnit,token){
    return{
        type:CREATE_EXTRAOPTION_PRICE,
        payload:async()=>{
            const response = await fetch(`${SERVER}/extraOptionPricing/create`,{
                method:'post',
                headers:{
                    'Content-Type':'application/json'
                },
                body:JSON.stringify({type:type,pricePerUnit:pricePerUnit,token:token})
            })
            const data = await response.json()
            return data
        }
    }
}

export function getExtraOptionPrice(token){
    return{
        type:GET_EXTRAOPTION_PRICE,
        payload:async()=>{
            const response = await fetch(`${SERVER}/extraOptionPricing/all`,{
                method:'post',
                headers:{
                    'Content-Type':'application/json'
                },
                body:JSON.stringify({token:token})
            })
            const data = await response.json()
            return data
        }
    }
}

export function createExtraOption(idSubscription,type,number,token){
    return{
        type:CREATE_EXTRAOPTION,
        payload:async()=>{
            let response = await fetch(`${SERVER}/extraOption/create`,{
                method:'post',
                headers:{
                    'Content-Type':'application/json'
                },
                body:JSON.stringify({idSubscription:idSubscription,type:type,number:number,token:token})
            })
            let data={message:"",extraOptionList:[]}
            data.message = (await response.json()).message

            response = await fetch(`${SERVER}/extraOption/allForSubscription`,{
                method:'post',
                headers:{
                    'Content-Type':'application/json'
                },
                body:JSON.stringify({idSubscription:idSubscription,token:token})
            })

           data.extraOptionList = (await response.json()).extraOptions

            return data
        }
    }
}

export function getExtraOption(idSubscription,token){
    return{
        type:GET_EXTRAOPTION,
        payload:async()=>{
            const response = await fetch(`${SERVER}/extraOption/allForSubscription`,{
                method:'post',
                headers:{
                    'Content-Type':'application/json'
                },
                body:JSON.stringify({idSubscription:idSubscription,token:token})
            })

            const data = await response.json()
            return data
        }
    }
}

