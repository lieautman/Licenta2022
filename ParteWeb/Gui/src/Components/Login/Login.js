import React,{useState} from 'react';
import {useSelector,shallowEqual,useDispatch}from 'react-redux'
import * as actions from '../../Actions'

export default function Login() {
  const [usernameL, setUsernameL] = useState(null);
  const [passwordL, setPasswordL] = useState(null);

  const dispatch = useDispatch()

  const login=()=>{
    dispatch(actions.mainActions.login(usernameL,passwordL))
  }
  const signup=()=>{
    dispatch(actions.mainActions.go_signup())
  }
  const isEnterPressed=(evt)=>{
    const key=evt.key
    if(key==='Enter'){
      login()
    }
}


  return(
    <div class="content-forms">
        <form>
          <h3>Login</h3>
          <label>
            <p>Username</p>
            <input type="text" placeholder="Enter Username" onChange={(evt)=>setUsernameL(evt.target.value)} onKeyPress={(evt)=>isEnterPressed(evt)}/>
          </label>
          <label>
            <p>Password</p>
            <input type="password" placeholder="Enter password" onChange={(evt)=>setPasswordL(evt.target.value)} onKeyPress={(evt)=>isEnterPressed(evt)}/>
          </label>
        </form>
        <div class="button-area">
          <div class="form-button">
              <input type="button" value="Login" onClick={login}></input>
          </div>
          <div class="form-button">
            <input type="button" value="Signup" onClick={signup}></input>
          </div>
        </div>
    </div>
  )
}