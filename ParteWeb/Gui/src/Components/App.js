import Login from "./Login/Login"
import Signup from "./Signup/Signup"
import Main from "./Main/Main"

//iau starea redux
import {useSelector,shallowEqual}from 'react-redux'

//var de selector
const pageSelector=state=>state.main.page
const idSelector=state=>state.main.id
const usernameSelector=state=>state.main.username
const typeSelector=state=>state.main.type
const tokenSelector=state=>state.main.token
const messageSelector=state=>state.main.message

function App() {
  //var din store
  const page=useSelector(pageSelector,shallowEqual)
  const id=useSelector(idSelector,shallowEqual)
  const username=useSelector(usernameSelector,shallowEqual)
  const type=useSelector(typeSelector,shallowEqual)
  const token=useSelector(tokenSelector,shallowEqual)
  const message=useSelector(messageSelector,shallowEqual)

  //schimba valoare dupa valoare variabilei page
  function chooseDisplay(page){
    switch (page){
      case 'Login':
        return <Login></Login>
      case 'Main':
        return <Main></Main>
      case 'Signup':
        return <Signup></Signup>
      default:
        return <Login></Login>
    }
  }
  return (
    <>
      <p>Stats:{page},{id},{username},{type},{token},{message}</p>
      {chooseDisplay(page)}
    </>
  );

}

export default App;