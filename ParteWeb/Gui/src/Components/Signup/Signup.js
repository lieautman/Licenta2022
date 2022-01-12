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
        <div class="content-forms">
            <div class="div-glass-background">
                <form>
                    <h3>Sign Up</h3>
                    <label>
                        <p>First name</p>
                        <input type="text" className="form-control" placeholder="First name" onChange={(evt)=>setFirstName(evt.target.value)} onKeyPress={(evt)=>isEnterPressed(evt)}/>
                    </label>
                    <label>
                        <p>Last name</p>
                        <input type="text" className="form-control" placeholder="Last name" onChange={(evt)=>setLastName(evt.target.value)} onKeyPress={(evt)=>isEnterPressed(evt)}/>
                    </label>
                    <label>
                        <p>Year of birth</p>
                        <input type="text" className="form-control" placeholder="Enter year of birth" onChange={(evt)=>setBirthYear(evt.target.value)} onKeyPress={(evt)=>isEnterPressed(evt)}/>
                    </label>
                    <label>
                        <p>Email address</p>
                        <input type="email" className="form-control" placeholder="Enter email" onChange={(evt)=>setEmail(evt.target.value)} onKeyPress={(evt)=>isEnterPressed(evt)}/>
                    </label>
                    <label>
                        <p>Username</p>
                        <input type="text" className="form-control" placeholder="Enter Username" onChange={(evt)=>setUsername(evt.target.value)} onKeyPress={(evt)=>isEnterPressed(evt)}/>
                    </label>
                    <label>
                        <p>Password</p>
                        <input type="password" className="form-control" placeholder="Enter password" onChange={(evt)=>setPassword(evt.target.value)} onKeyPress={(evt)=>isEnterPressed(evt)}/>
                    </label>
                </form>
                <div class="button-area">
                    <div class="form-button">
                        <input type="button" value="Sign Up" onClick={signup}></input>
                    </div>
                    <div class="form-button">
                        <input type="button" value="Back to login" onClick={back}></input>
                    </div>
                </div>
                <div>{message}</div>
            </div>
        </div>
    )
}