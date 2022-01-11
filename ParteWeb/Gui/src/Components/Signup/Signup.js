import React,{useState} from 'react';
import {useSelector,shallowEqual,useDispatch}from 'react-redux'
import * as actions from '../../Actions'

//preluare mesaj de eroare sau reusita la creare
const messageSelector=state=>state.main.message

export default function Signup() {
    //var locale pentru parametrii
    const [firstName, setFirstName] = useState(null);
    const [lastName, setLastName] = useState(null);
    const [birthYear, setBirthYear] = useState(null);
    const [email, setEmail] = useState(null);
    const [username, setUsername] = useState(null);
    const [password, setPassword] = useState(null);

    //preluare mesaj
    const message = useSelector(messageSelector,shallowEqual)

    const dispatch = useDispatch()
    const back=()=>{
        dispatch(actions.mainActions.go_login())
    }
    const signup=()=>{
        dispatch(actions.mainActions.signup(firstName,lastName,birthYear,email,username,password));
       // dispatch(actions.mainActions.go_login())
    }
    const isEnterPressed=(evt)=>{
        const key=evt.key
        if(key==='Enter'){
            signup()
        }
    }

    return(
        <div>
            <form>
                <h3>Sign Up</h3>

                <div className="form-group">
                    <label>First name</label>
                    <input type="text" className="form-control" placeholder="First name" onChange={(evt)=>setFirstName(evt.target.value)} onKeyPress={(evt)=>isEnterPressed(evt)}/>
                </div>

                <div className="form-group">
                    <label>Last name</label>
                    <input type="text" className="form-control" placeholder="Last name" onChange={(evt)=>setLastName(evt.target.value)} onKeyPress={(evt)=>isEnterPressed(evt)}/>
                </div>

                <div className="form-group">
                    <label>Year of birth</label>
                    <input type="text" className="form-control" placeholder="Enter year of birth" onChange={(evt)=>setBirthYear(evt.target.value)} onKeyPress={(evt)=>isEnterPressed(evt)}/>
                </div>

                <div className="form-group">
                    <label>Email address</label>
                    <input type="email" className="form-control" placeholder="Enter email" onChange={(evt)=>setEmail(evt.target.value)} onKeyPress={(evt)=>isEnterPressed(evt)}/>
                </div>

                <div className="form-group">
                    <label>Username</label>
                    <input type="text" className="form-control" placeholder="Enter Username" onChange={(evt)=>setUsername(evt.target.value)} onKeyPress={(evt)=>isEnterPressed(evt)}/>
                </div>

                <div className="form-group">
                    <label>Password</label>
                    <input type="password" className="form-control" placeholder="Enter password" onChange={(evt)=>setPassword(evt.target.value)} onKeyPress={(evt)=>isEnterPressed(evt)}/>
                </div>

                <div>
                    <input type="button" value="Sign Up" onClick={signup}></input>
                </div>
            </form>

            <input type="button" value="Back to login" onClick={back}></input>
            <div>{message}</div>
        </div>
    )
}