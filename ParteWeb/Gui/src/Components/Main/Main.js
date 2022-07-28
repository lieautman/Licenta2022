import React,{useState, useEffect} from 'react';
import {useSelector,shallowEqual,useDispatch}from 'react-redux'
import * as actions from '../../Actions'

const idAccountSelector=state=>state.main.id
const idClientSelector=state=>state.main.idClient
const firstNameClientSelector=state=>state.main.firstName
const lastNameClientSelector=state=>state.main.lastName
const usernameClientSelector=state=>state.main.username
const tokenSelector=state=>state.main.token

const subscriptionTypeListSelector=state=>state.subscriptionType.subscriptionTypeList
const subscriptionListSelector=state=>state.subscription.subscriptionList

const extraOptionPricingSelector=state=>state.extraOption.extraOptionPriceList
const extraOptionMessageSelector=state=>state.extraOption.message
const extraOptionListSelector=state=>state.extraOption.extraOptionList

export default function Main() {

  const back=(evt)=>{
    dispatch(actions.mainActions.go_login())
  }

  const idAccount=useSelector(idAccountSelector,shallowEqual)
  const idClient=useSelector(idClientSelector,shallowEqual)
  const firstNameClient=useSelector(firstNameClientSelector,shallowEqual)
  const lastNameClient=useSelector(lastNameClientSelector,shallowEqual)
  const usernameClient=useSelector(usernameClientSelector,shallowEqual)
  const token=useSelector(tokenSelector,shallowEqual)

  const subscriptionTypeList=useSelector(subscriptionTypeListSelector,shallowEqual)
  const subscriptionList=useSelector(subscriptionListSelector,shallowEqual)

  const extraOptionPricing=useSelector(extraOptionPricingSelector,shallowEqual)
  const extraOptionMessage=useSelector(extraOptionMessageSelector,shallowEqual)
  const extraOptionList=useSelector(extraOptionListSelector,shallowEqual)
  const dispatch = useDispatch()

  //preluam listele
  useEffect(()=>{
    dispatch(actions.subscriptionTypeActions.getSubscriptionType(token))
    dispatch(actions.subscriptionActions.getSubscription(token))
    dispatch(actions.extraOption.getExtraOptionPrice(token))
  },[dispatch,token])
  //afiseaza tipurile de abonament
  function afisareListaTipuriAbonamente(){
    if(subscriptionTypeList!==undefined){
      if(subscriptionTypeList.length===0){
        return null
      }
      else{
        return subscriptionTypeList.map(e=><div key={e.idSubscriptionType}>nrMesage: {e.nrMessages}; nrMinute: {e.nrMinutes};  nrGbInternet: {e.nrGbInternet}; pret: {e.price}</div>)
      }
    }
    else{
      return null
    }
  }
  //preluam id-ul tipului de abonament pentru a putea adauga un abonament
  const [idSubscriptionTypeInFormularAbonamente,setIdSubscriptionTypeInFormularAbonamente]=useState(null);
  const [dataStartAbonament,setDataStartAbonament]=useState(null);
  const [reccuring,setReccuring]=useState("false");
  //il setam la inceput si cand se modifica lista de tipuri
  useEffect(()=>{
    if(subscriptionTypeList!==undefined){
      if(subscriptionTypeList.length!==0){
        setIdSubscriptionTypeInFormularAbonamente(subscriptionTypeList[0].idSubscriptionType)
        setIdSubscriptionTypeInFormularAbonamenteInUpdate(subscriptionTypeList[0].idSubscriptionType)
      }
    }
  },[subscriptionTypeList])
  //afiseaza tipurile de abonamente in formularul de abonamente
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
  //creaza un abonament
  function creareAbonament(){
    console.log(reccuring)
    dispatch(actions.subscriptionActions.createSubscription(idClient,idSubscriptionTypeInFormularAbonamente,dataStartAbonament,reccuring,token))
  }

  //afiseaza tipul de abonamente in afiseaza abonamente
  function afisareInFunctieAbonamentTip(id1,id2,nrMessages,nrMinutes,nrGbInternet,price){
    if(id1===id2){
      return (<React.Fragment key={id1}>Nr mesaje: {nrMessages}; <br/> Nr minute: {nrMinutes}; <br/> Nr GB Internet: {nrGbInternet};  <br/>Pret: {price};</React.Fragment>)
    }
    else{
      return null
    }
  }
  function afisareListaTipuriAbonamenteInAbonamenteleTale(idSubscriptionType){
    if(subscriptionTypeList!==undefined){
      if(subscriptionTypeList.length===0){
        return null
      }
      else{
        return subscriptionTypeList.map(e=>afisareInFunctieAbonamentTip(e.idSubscriptionType,idSubscriptionType,e.nrMessages,e.nrMinutes,e.nrGbInternet,e.price))
      }
    }
    else{
      return null
    }
  }
  const [idSubscriptionSelected, setIdSubscriptionSelected] = useState(null);
  const [isUpdateHidden, setIsUpdateHidden] = useState(true);
  //afiseaza formular pentru a edita abonamentul si a adauga extraoptiuni
  function editAbonament(idSubscription){
    dispatch(actions.extraOption.getExtraOption(idSubscription,token))
    setIdSubscriptionSelected(idSubscription)
    if(isUpdateHidden)
    setIsUpdateHidden(false)
  }
  //sterge abonamentul
  function deleteAbonament(idSubscription){
    dispatch(actions.subscriptionActions.deleteSubscription(token,idSubscription))
    setIsUpdateHidden(true)
  }
  
  //afiseaza lista de abonamente ale utilizatorului curent(posibil sa o leg si cu ideea de SIM-uri)
  function afisareListaAbonamente(){
    if(subscriptionList!==undefined){
        if(subscriptionList.length===0){
        return null
      }
      else{
        return subscriptionList.map(e=>
          <div className="tooltip" key={e.idSubscription}>
            Id abonament: {e.idSubscription};&ensp;
            <div className="tooltiptext">
              Detalii client: <br/>Id client: {e.idClient};  <br/>Nume client: {firstNameClient} {lastNameClient}; <br/> Username client: {usernameClient};
              <br/>
              <br/>
              Detalii abonament: <br/>Id abonament: {e.idSubscription};  <br/>Data de inceput: {e.dataStart};  <br/>Reccuring: {e.reccuring};
              <br/>
              <br/>
              Detalii tip abonament:  <br/>Id tip abonament: {e.idSubscriptionType};  <br/>{afisareListaTipuriAbonamenteInAbonamenteleTale(e.idSubscriptionType)}
              </div>
              <input type="button" value="Edit" onClick={()=>editAbonament(e.idSubscription)}></input>
              &ensp;
              <input type="button" value="Delete" onClick={()=>deleteAbonament(e.idSubscription)}></input>
          </div>
          )
      }
    }
    else{
      return null
    }
  }

  //preluam date abonament pentru actualizare
  const [idSubscriptionTypeInFormularAbonamenteInUpdate,setIdSubscriptionTypeInFormularAbonamenteInUpdate]=useState(null);
  const [dataStartAbonamentInUpdate,setDataStartAbonamentInUpdate]=useState(null);
  const [reccuringInUpdate,setReccuringInUpdate]=useState("false");

  //preluam date pentru a adauga o extraoptiune
  const [typeExtraOption, setTypeExtraOption] = useState("minute");
  const [nrExtraOption, setNrExtraOption] = useState(0);
  const [pretTotalExtraOption,setPretTotalExtraOption] = useState(0);
  function showUpdateScreen(){
    if(isUpdateHidden){
      return null
    }
    else{
      let placeHolderString=`Numar de ${typeExtraOption}`;
      let valCampExtraOptiune=0;
      return(
        <>
          <br/>
          <div>Selecteaza alt tip de abonament pentru abonamentul cu id-ul: {idSubscriptionSelected}; </div>
          <select className="form-control" onChange={(evt)=>{setIdSubscriptionTypeInFormularAbonamenteInUpdate(evt.target.value)}}>
            {afisareListaTipuriAbonamenteInFormularAbonamente()}
          </select><br/>
              <label>Data de inceput (goala pentru data de astazi): </label><br/>
              <input type="date" onChange={(evt)=>setDataStartAbonamentInUpdate(evt.target.value)}></input><br/>
              <label>Reccuring: </label><br/>
              <input type="checkbox" onClick={(evt)=>
                {
                  if(reccuring==="false")
                    setReccuringInUpdate("true")
                  else
                    setReccuringInUpdate("false")
                }}></input><br/>
          <input type="button" value="Update" onClick={()=>updateAbonament()}></input>
          &ensp;
          <input type="button" value="Cancel" onClick={()=>cancelEditAbonament()}></input>
          <br/>
          <br/>

          <div>Asociati o extraoptiune:</div>
          <select className="form-control" onChange={(evt)=>{
              valCampExtraOptiune=evt.target.value
              setTypeExtraOption(valCampExtraOptiune)
              setPretTotalExtraOption(nrExtraOption*extraOptionPricing.filter(obj=>{return obj.type===valCampExtraOptiune})[0].pricePerUnit)
            }}>
            <option value="minute">Numar minute</option>
            <option value="mesaje">Numar mesaje</option>
            <option value="gb internet">Numar GB internet</option>
          </select>
          <input type="text" placeholder={placeHolderString} onChange={(evt)=>{
            valCampExtraOptiune=parseInt(evt.target.value,10)
            setPretTotalExtraOption(valCampExtraOptiune*extraOptionPricing.filter(obj=>{return obj.type===typeExtraOption})[0].pricePerUnit)
            setNrExtraOption(valCampExtraOptiune)
          }}/>
          <div>Pretul pentru aceasta va fi: {pretTotalExtraOption}</div>
          <input type="button" value="Adauga" onClick={()=>{adaugaExtraOptiune()}}></input>
          &ensp;
          <input type="button" value="Cancel" onClick={()=>cancelEditAbonament()}></input>
          <br/>
          {extraOptionMessage}
          <br/>
          <div>Lista de extraoptiuni pentru abonamentul selectat:</div>
          {afisazaExtraOptiuni()}
        </>
      )
    }
  }

  //actualizeaza un abonament
  function updateAbonament(){
    dispatch(actions.subscriptionActions.updateSubscription(idAccount,idSubscriptionTypeInFormularAbonamenteInUpdate,dataStartAbonamentInUpdate,reccuringInUpdate,token,idSubscriptionSelected))
  }

  function cancelEditAbonament(){
    setPretTotalExtraOption(0)
    setIsUpdateHidden(true)
  }
  //functii pentru extraoptiuni
  function adaugaExtraOptiune(){
    dispatch(actions.extraOption.createExtraOption(idSubscriptionSelected,typeExtraOption, nrExtraOption, token))
  }
  function deleteExtraoption(id){
    dispatch(actions.extraOption.deleteExtraOption(idSubscriptionSelected, id, token))
    
  }
  function afisazaExtraOptiuni(){
    if(extraOptionList!==undefined){
      if(extraOptionList.length===0){
        return null
      }
      else{
        return extraOptionList.map(e=><div key={e.idExtraOption}><br/> Id extraoptiune: {e.idExtraOption};<br/> Id abonament asociat: {e.idSubscription}; <br/>  Cu {e.type}; in numar de: {e.number} si cu pretul {e.price}  <input type="button" value="Delete" onClick={()=>deleteExtraoption(e.idExtraOption)}></input></div>)
      }
    }
    else{
      return null
    }
  }

  return(
    <>
      <input id="buttonLogOut" type="button" value="Log out" onClick={back}></input>
      <div className="content-main">
        <div className="div-glass-background-main">


          <div><h3>Tipuri de abonamente:</h3>{afisareListaTipuriAbonamente()}</div>

          <form>
            <h3>Adauga-ti un abonament</h3>

            <div className="form-group">
              <label>Tipuri de abonamente posibile: </label><br/>
              <select className="form-control" onChange={(evt)=>{setIdSubscriptionTypeInFormularAbonamente(evt.target.value)}}>
                  {afisareListaTipuriAbonamenteInFormularAbonamente()}
              </select><br/>
              <label>Data de inceput (goala pentru data de astazi): </label><br/>
              <input type="date" onChange={(evt)=>setDataStartAbonament(evt.target.value)}></input><br/>
              <label>Reccuring: </label><br/>
              <input type="checkbox" onClick={(evt)=>
                {
                  if(reccuring==="false")
                    setReccuring("true")
                  else
                    setReccuring("false")
                }}></input><br/>
            </div>

            <div>
              <input type="button" value="Adaugare" onClick={creareAbonament}></input>
            </div>
          </form>

          <div><h3>Abonamentele tale:</h3>{afisareListaAbonamente()}</div>


          {showUpdateScreen()}
        </div>
      </div>
    </>
  )
}