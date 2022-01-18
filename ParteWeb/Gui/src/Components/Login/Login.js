import React,{useState} from 'react';
import {useSelector,shallowEqual,useDispatch}from 'react-redux'
import * as actions from '../../Actions'

const loginMessageSelector=state=>state.main.message

export default function Login() {
  const loginMessage=useSelector(loginMessageSelector,shallowEqual)


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
    <div className="content-forms">
      <div className="div-glass-background">
          <form>
            <h3>Login</h3>
            {loginMessage}
            <label>
              <p>Username</p>
              <input type="text" placeholder="Enter Username" onChange={(evt)=>setUsernameL(evt.target.value)} onKeyPress={(evt)=>isEnterPressed(evt)}/>
            </label>
            <label>
              <p>Password</p>
              <input type="password" placeholder="Enter password" onChange={(evt)=>setPasswordL(evt.target.value)} onKeyPress={(evt)=>isEnterPressed(evt)}/>
            </label>
          </form>
          <div className="button-area">
            <div className="form-button">
                <input type="button" value="Login" onClick={login}></input>
            </div>
            <div className="form-button">
              <input type="button" value="Signup" onClick={signup}></input>
            </div>
          </div>
      </div>
    </div>
  )
}