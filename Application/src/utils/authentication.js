import React, { Component } from 'react';
import { validateToken } from '../actions/authAction';
import axios from 'axios';

class Authentication extends Component {
    componentWillMount() {
        if (this.props.user) {
            this.props.validateToken(this.props.auth.user.token)
        }
    }

    render() {
        const { user, validaToken } = this.props.auth
        if (user && validToken) {
            axios.defaults.headers.common['authorization'] = user.token
            
        }
    }
}