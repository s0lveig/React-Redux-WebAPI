import React, { Component } from 'react';
import { BrowserRouter, Route, Switch, Link } from 'react-router-dom';
import AllChairs from './AllChairs';
import CreateChair from './CreateChair';

class Nav extends Component {
    render() {

        return(
            <section>
                <h1>navigation</h1>
                <nav>
                    <BrowserRouter>
                        <ul>
                            <li><Link to="/">All Chairs</Link></li>
                            <li><Link to="/createchair">Create Chair</Link></li>
                        </ul>
                        <Switch>
                            <Route exact path="/" component={AllChairs} />
                            <Route path="/createchair" component={CreateChair} />
                        </Switch>
                    </BrowserRouter>
                </nav>
            </section>
        )
    }
}

export default Nav;