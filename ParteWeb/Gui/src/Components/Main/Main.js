import React,{useState, useEffect} from 'react';
import {useSelector,shallowEqual,useDispatch}from 'react-redux'
import * as actions from '../../Actions'

const idClientSelector=state=>state.main.id
const tokenSelector=state=>state.main.token
const subscriptionTypeListSelector=state=>state.subscriptionType.subscriptionTypeList
const subscriptionListSelector=state=>state.subscription.subscriptionList

export default function Main() {
  const idClient=useSelector(idClientSelector,shallowEqual)
  const token=useSelector(tokenSelector,shallowEqual)
  const subscriptionTypeList=useSelector(subscriptionTypeListSelector,shallowEqual)
  const subscriptionList=useSelector(subscriptionListSelector,shallowEqual)

  const [nrMesaje, setNrMesaje] = useState(null);
  const [nrMinute, setNrMinute] = useState(null);
  const [nrGbInternet, setNrGbInternet] = useState(null);
  const [pret, setPret] = useState(null);

  const dispatch = useDispatch()

  function creareTipAbonament(){
    dispatch(actions.subscriptionTypeActions.createSubscriptionType(nrMesaje,nrMinute,nrGbInternet,pret,token))
  }

  useEffect(()=>{
    dispatch(actions.subscriptionTypeActions.getSubscriptionType(token))
    dispatch(actions.subscriptionActions.getSubscription(token))
  },[dispatch])

  function afisareListaTipuriAbonamente(){
    if(subscriptionTypeList!==undefined){
      if(subscriptionTypeList.length===0){
        return subscriptionTypeList.map(e=><div key={e.idSubscriptionType}>nrMesage: {e.nrMessages}; nrMinute: {e.nrMinutes};  nrGbInternet: {e.nrGbInternet}; pret: {e.price}</div>)
      }
      else{
        return null
      }
    }
    else{
      return null
    }
  }

  const [idSubscriptionTypeInFormularAbonamente,setIdSubscriptionTypeInFormularAbonamente]=useState(null);

  useEffect(()=>{
    if(subscriptionTypeList!==undefined){
      if(subscriptionTypeList.length===0){
        setIdSubscriptionTypeInFormularAbonamente(1000)
      }
      else{
        setIdSubscriptionTypeInFormularAbonamente(subscriptionTypeList[0].idSubscriptionType)
      }
    }
    else{
      setIdSubscriptionTypeInFormularAbonamente(1000)
    }
  },[subscriptionTypeList])

  function afisareListaTipuriAbonamenteInFormularAbonamente(){
    if(subscriptionTypeList!==undefined){
      if(subscriptionTypeList.length===0){
        return <option key={0} value={0}>Nu exista tipuri de abonamente inca</option>
      }
      else{
        return subscriptionTypeList.map(e=><option key={e.idSubscriptionType} value={e.idSubscriptionType}>nrMesage: {e.nrMessages}; nrMinute: {e.nrMinutes};  nrGbInternet: {e.nrGbInternet}; pret: {e.price}</option>)
      }
    }
    else{
      return <option key={0} value={0}>Nu exista tipuri de abonamente inca</option>
    }
  }

  function creareAbonament(){
    dispatch(actions.subscriptionActions.createSubscription(idClient,idSubscriptionTypeInFormularAbonamente,token))
  }

  //se poate face mai frumos
  function afisareListaAbonamente(){
    if(subscriptionList!==undefined){
        if(subscriptionList.length===0){
        return null
      }
      else{
        return subscriptionList.map(e=><div key={e.idSubscription}>{e.idSubscription},{e.idClient},{e.idSubscriptionType}</div>)
      }
    }
    else{
      return null
    }
  }

  const back=(evt)=>{
    dispatch(actions.mainActions.go_login())
  }
  return(
    <div>
      <input type="button" value="Log out" onClick={back}></input>
    
        <form>
          <h3>Adaugare tip de abonament</h3>
          <label>
            <p>nrMesaje</p>
            <input type="text" placeholder="Enter nrMesaje" onChange={(evt)=>setNrMesaje(evt.target.value)}/>
          </label>
          <label>
            <p>nrMinute</p>
            <input type="text" placeholder="Enter nrMinute" onChange={(evt)=>setNrMinute(evt.target.value)}/>
          </label>
          <label>
            <p>nrGbInternet</p>
            <input type="text" placeholder="Enter nrGbInternet" onChange={(evt)=>setNrGbInternet(evt.target.value)}/>
          </label>
          <label>
            <p>pret</p>
            <input type="text" placeholder="Enter pret" onChange={(evt)=>setPret(evt.target.value)}/>
          </label>
          <div>
            <input type="button" value="Creare" onClick={creareTipAbonament}></input>
          </div>
        </form>

        <div><h3>Tipuri de abonamente:</h3>{afisareListaTipuriAbonamente()}</div>

        <form>
          <h3>Adauga-ti un abonament</h3>

          <div className="form-group">
            <label>Tipuri de abonamente posibile: </label>
            <select className="form-control" onChange={(evt)=>{setIdSubscriptionTypeInFormularAbonamente(evt.target.value)}}>
                {afisareListaTipuriAbonamenteInFormularAbonamente()}
            </select>
          </div>

          <div>
            <input type="button" value="Adaugare" onClick={creareAbonament}></input>
          </div>
        </form>

        <div><h3>Abonamentele tale:</h3>{afisareListaAbonamente()}</div>
    </div>
  )
}