import {SERVER_GLOBAL}from'../Configs/globals'
const SERVER = SERVER_GLOBAL

export const GO_LOGIN='Go_Login';
export const GO_SIGNUP='Go_Signup';
export const GO_MAIN='Go_Main';
export const SIGNUP='Signup';
export const LOGIN='Login';


export function go_login(){
    return{
        type:GO_LOGIN
    }
}
export function go_signup(){
    return{
        type:GO_SIGNUP
    }
}
export function signup(firstName,lastName,email,birthYear,paymentMethod,username,password){
    return{
        type:SIGNUP,
        payload:async()=>{
            const response = await fetch(`${SERVER}/account/signup_web`,{
                method:'post',
                headers:{
                    'Content-Type':'application/json'
                },
                body:JSON.stringify({firstName:firstName,lastName:lastName,email:email,birthYear:birthYear,paymentMethod:paymentMethod,username:username,password:password,type:'client'})
            })
            const data = await response.json()
            return data
        }
    }
}
export function login(username,password){
    return{
        type:LOGIN,
        payload:async()=>{
            const response = await fetch(`${SERVER}/account/login_web`,{
                method:'post',
                headers:{
                    'Content-Type':'application/json'
                },
                body:JSON.stringify({username:username,password:password})
            })
            let data= await response.json()
            if(data.id&&data.firstName&&data.lastName&&data.birthYear&&data.username&&data.type&&data.token){
                data.page='Main'
                data.message='Utilizator logat'
            }
            return data
        }
    }
}