import React from 'react';
import { Switch, Route, Redirect } from 'react-router';
import User from '../components/system/user/user';
import Profile from '../components/system/profile/profile';
import Home from '../components/home/home';

export default props => (
    <div className="content-wrapper">
        <Switch>
            <Route exact path="/" component={Home} />
            <Route path="/user" component={User} />
            <Route path="/profile" component={Profile} />
            <Redirect from="*" to="/" />
        </Switch>
    </div>
)