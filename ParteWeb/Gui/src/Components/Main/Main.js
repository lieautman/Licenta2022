import React,{useState, useEffect} from 'react';
import {useSelector,shallowEqual,useDispatch}from 'react-redux'
import * as actions from '../../Actions'

const idAccountSelector=state=>state.main.id
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
  const firstNameClient=useSelector(firstNameClientSelector,shallowEqual)
  const lastNameClient=useSelector(lastNameClientSelector,shallowEqual)
  const usernameClient=useSelector(usernameClientSelector,shallowEqual)
  const token=useSelector(tokenSelector,shallowEqual)

  const subscriptionTypeList=useSelector(subscriptionTypeListSelector,shallowEqual)
  const subscriptionList=useSelector(subscriptionListSelector,shallowEqual)

  const extraOptionPricing=useSelector(extraOptionPricingSelector,shallowEqual)
  const extraOptionMessage=useSelector(extraOptionMessageSelector,shallowEqual)
  const extraOptionList=useSelector(extraOptionListSelector,shallowEqual)

  //var pt adaug tip abonament
  const [nrMesaje, setNrMesaje] = useState(null);
  const [nrMinute, setNrMinute] = useState(null);
  const [nrGbInternet, setNrGbInternet] = useState(null);
  const [pret, setPret] = useState(null);

  const dispatch = useDispatch()
  //functie de creare tip abonament
  function creareTipAbonament(){
    dispatch(actions.subscriptionTypeActions.createSubscriptionType(nrMesaje,nrMinute,nrGbInternet,pret,token))
  }
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
  //il setam la inceput si cand se modifica lista de tipuri
  useEffect(()=>{
    if(subscriptionTypeList!==undefined){
      if(subscriptionTypeList.length!==0){
        setIdSubscriptionTypeInFormularAbonamente(subscriptionTypeList[0].idSubscriptionType)
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
    dispatch(actions.subscriptionActions.createSubscription(idAccount,idSubscriptionTypeInFormularAbonamente,token))
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
  //afiseaza tipul de abonamente in afiseaza abonamente
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

  //sterge abonamentul
  function deleteAbonament(idSubscription){
    dispatch(actions.subscriptionActions.deleteSubscription(token,idSubscription))
  }

  const [idSubscriptionSelected, setIdSubscriptionSelected] = useState(null);
  const [isUpdateHidden, setIsUpdateHidden] = useState(true);
  //preluam id-ul tipului de abonament pentru a putea adauga un abonament
  const [idSubscriptionTypeInFormularAbonamenteInUpdate,setIdSubscriptionTypeInFormularAbonamenteInUpdate]=useState(null);
  //afiseaza formular pentru a edita abonamentul si a adauga extraoptiuni
  function editAbonament(idSubscription){
    dispatch(actions.extraOption.getExtraOption(idSubscription,token))
    setIdSubscriptionSelected(idSubscription)
    if(isUpdateHidden)
      setIsUpdateHidden(false)
  }
  function cancelEditAbonament(){
    setPretTotalExtraOption(0)
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
              Detalii client: <br/>Id client: {e.idAccount};  <br/>Nume client: {firstNameClient} {lastNameClient}; <br/> Username client: {usernameClient};
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
  //actualizeaza un abonament
  function updateAbonament(){
    dispatch(actions.subscriptionActions.updateSubscription(idAccount,idSubscriptionTypeInFormularAbonamenteInUpdate,token,idSubscriptionSelected))
  }

  const [typeExtraOption, setTypeExtraOption] = useState("minute");
  const [nrExtraOption, setNrExtraOption] = useState("minute");
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
          </select>
          <br/>
          <input type="button" value="Update" onClick={()=>updateAbonament()}></input>
          &ensp;
          <input type="button" value="Cancel" onClick={()=>cancelEditAbonament()}></input>



          <div>Creati o extraoptiune:</div>
          <select className="form-control" onChange={(evt)=>{setTypeExtraOption(evt.target.value)}}>
            <option value="minute">Numar minute</option>
            <option value="mesaje">Numar mesaje</option>
            <option value="gb internet">Numar GB internet</option>
          </select>
          <input type="text" placeholder={placeHolderString} onChange={(evt)=>{
            setNrExtraOption(evt.target.value)
          }}/>
          <div>Pretul pentru aceasta va fi: </div>
          <input type="button" value="Adauga" onClick={()=>adaugaExtraOptiunePret()}></input>
          &ensp;
          <input type="button" value="Cancel" onClick={()=>cancelEditAbonament()}></input>



          <div>Asociati o extraoptiune:</div>
          <select className="form-control" onChange={(evt)=>{
              setPretTotalExtraOption(0)
              setTypeExtraOption(evt.target.value)
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
          <br/>
          <div>Lista de extraoptiuni pentru abonamentul selectat:</div>
          {afisazaExtraOptiuni()}
        </>
      )
    }
  }

  function adaugaExtraOptiunePret(){
    dispatch(actions.extraOption.createExtraOptionPrice(typeExtraOption, nrExtraOption, token))
  }  
  function adaugaExtraOptiune(){
    dispatch(actions.extraOption.createExtraOption(idSubscriptionSelected,typeExtraOption, nrExtraOption, token))
  }

  function afisazaExtraOptiuni(){
    if(extraOptionList!==undefined){
      if(extraOptionList.length===0){
        return null
      }
      else{
        return extraOptionList.map(e=><div key={e.idExtraOption}><br/> Id extraoptiune: {e.idExtraOption};<br/> Id abonament asociat: {e.idSubscription}; <br/>  Cu {e.type}; in numar de: {e.number} si cu pretul {e.price}</div>)
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


          {showUpdateScreen()}
        </div>
      </div>
    </>
  )
}