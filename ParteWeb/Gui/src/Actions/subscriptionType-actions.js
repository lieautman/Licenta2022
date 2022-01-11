import {SERVER_GLOBAL}from'../Configs/globals'
const SERVER = SERVER_GLOBAL

export const CREATE_SUBSCRIPTIONTYPE='CREATE_SUBSCRIPTIONTYPE';
export const GET_SUBSCRIPTIONTYPE='GET_SUBSCRIPTIONTYPE';

export function createSubscriptionType(nrMesaje,nrMinute,nrGbInternet,pret,token){
    return{
        type:CREATE_SUBSCRIPTIONTYPE,
        payload:async()=>{
            let response = await fetch(`${SERVER}/subscriptionType/create`,{
                method:'post',
                headers:{
                    'Content-Type':'application/json'
                },
                body:JSON.stringify({nrMessages:nrMesaje,nrMinutes:nrMinute,nrGbInternet:nrGbInternet,price:pret,token:token})
            })
            let data = await response.json()
            response = await fetch(`${SERVER}/subscriptionType/all`,{
                method:'post',
                headers:{
                    'Content-Type':'application/json'
                },
                body:JSON.stringify({token:token})
            })
            data = await response.json()
            return data
        }
    }
}

export function getSubscriptionType(token){
    return{
        type:GET_SUBSCRIPTIONTYPE,
        payload:async()=>{
            const response = await fetch(`${SERVER}/subscriptionType/all`,{
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