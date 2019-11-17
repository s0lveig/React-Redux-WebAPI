import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import './App.css';
import Header from './Components/Header';
import Home from './Components/Home';
import Footer from './Components/Footer';
import ChairContainer from './Components/ChairContainer';
import TableContainer from './Components/TableContainer';

/**
 * The main project application page, containing the Routing funcionality.
 */
function App() {

  return (
    <div className="App">
      <BrowserRouter>
        <Route component={Header} />
          <main>
            <Switch>
              <Route exact path="/" component={Home} />
              <Route path="/chairs" component={ChairContainer} />
              <Route path="/tables" component={TableContainer} />
            </Switch>
          </main>
        <Route component={Footer} />
      </BrowserRouter>
    </div>
  );
}

export default App;
