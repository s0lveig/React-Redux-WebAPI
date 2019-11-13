import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
//import { useSelector, useDispatch } from 'react-redux';
//import { addChair } from './Actions';
import './App.css';
import Header from './Components/Header';
import Home from './Components/Home';
import Footer from './Components/Footer';
import ChairContainer from './Components/ChairContainer';
//import Nav from './Components/Nav';

function App() {

  
  /*
  const chairList = useSelector(state => state.chairList);
  const dispatch = useDispatch();

  const chairTitle = document.querySelector("#inputTitle");


  console.log(chairTitle);

  const getChairs = () => {
    let chairs = chairList.map( chair => {
      return <li>{ chair }</li>
    });
    return chairs;
  }*/
/*

  <input id="inputTitle" type="text" />
  <input onClick={ () => dispatch( addChair() ) } type="button" value="Add chair" />


  <ul>{ getChairs() }</ul>


    <input id="inputTitle" type="text" onChange={event => setTitle(event.target.value)} />
    <input onClick={ () => dispatch( addChair() ) } type="button" value="Add chair" />

    <ul>{ getChairs() }</ul>
  */
    

  return (
    <div className="App">
      <BrowserRouter>
        <Route component={Header} />
          <main>
            <Switch>
              <Route exact path="/" component={Home} />
              <Route path="/chairs" component={ChairContainer} />
            </Switch>
          </main>
        <Route component={Footer} />
      </BrowserRouter>
    </div>
  );
}

export default App;
