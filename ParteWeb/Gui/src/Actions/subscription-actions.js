import {SERVER_GLOBAL}from'../Configs/globals'
const SERVER = SERVER_GLOBAL

export const CREATE_SUBSCRIPTION='CREATE_SUBSCRIPTION';
export const GET_SUBSCRIPTION='GET_SUBSCRIPTION';

export function createSubscription(idClient,idSubscriptionType,token){
    return{
        type:CREATE_SUBSCRIPTION,
        payload:async()=>{
            let response = await fetch(`${SERVER}/subscription/create`,{
                method:'post',
                headers:{
                    'Content-Type':'application/json'
                },
                body:JSON.stringify({idClient:idClient,idSubscriptionType:idSubscriptionType,token:token})
            })
            let data = await response.json()
            response = await fetch(`${SERVER}/subscription/all`,{
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

export function getSubscription(token){
    return{
        type:GET_SUBSCRIPTION,
        payload:async()=>{
            const response = await fetch(`${SERVER}/subscription/all`,{
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