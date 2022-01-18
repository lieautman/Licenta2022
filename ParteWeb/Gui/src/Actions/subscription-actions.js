import {SERVER_GLOBAL}from'../Configs/globals'
const SERVER = SERVER_GLOBAL

export const CREATE_SUBSCRIPTION='CREATE_SUBSCRIPTION';
export const GET_SUBSCRIPTION='GET_SUBSCRIPTION';
export const DELETE_SUBSCRIPTION='DELETE_SUBSCRIPTION';
export const UPDATE_SUBSCRIPTION='UPDATE_SUBSCRIPTION';

export function createSubscription(idAccount,idSubscriptionType,token){
    return{
        type:CREATE_SUBSCRIPTION,
        payload:async()=>{
            let response = await fetch(`${SERVER}/subscription/create`,{
                method:'post',
                headers:{
                    'Content-Type':'application/json'
                },
                body:JSON.stringify({idAccount:idAccount,idSubscriptionType:idSubscriptionType,token:token})
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

export function deleteSubscription(token,id){
    return{
        type:DELETE_SUBSCRIPTION,
        payload:async()=>{
            let response = await fetch(`${SERVER}/subscription/delete/${id}`,{
                method:'delete',
                headers:{
                    'Content-Type':'application/json'
                },
                body:JSON.stringify({token:token})
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

export function updateSubscription(idAccount,idSubscriptionType,token,idSubscription){
    return{
        type:CREATE_SUBSCRIPTION,
        payload:async()=>{
            let response = await fetch(`${SERVER}/subscription/update/${idSubscription}`,{
                method:'put',
                headers:{
                    'Content-Type':'application/json'
                },
                body:JSON.stringify({idAccount:idAccount,idSubscriptionType:idSubscriptionType,token:token})
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