import React from 'react';
import { Switch, Route, Redirect } from 'react-router';
import User from '../components/users/user';
import Home from '../components/home/home';

export default props => (
    <div className="content-wrapper">
        <Switch>
            <Route exact path="/" component={Home} />
            <Route path="/user" component={User} />
            <Redirect from="*" to="/" />
        </Switch>
    </div>
)