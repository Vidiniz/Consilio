import React, { Component } from 'react';
import { valiteTokenRequest } from '../actions/authAction';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import axios from 'axios';
import Auth from './auth';
import App from '../main/app';

class Authentication extends Component {
    componentWillMount() {
        if (this.props.auth.user) {            
            this.props.valiteTokenRequest(this.props.auth.user.token)
        }
    }

    render() {
        const { user, validToken } = this.props.auth
        if (user && validToken) {
            axios.defaults.headers.common['authorization'] = `Bearer ${user.token}` 
            return <App />
        }
        else if(!user && !validToken) {
            return <Auth />            
        } 
        else if(user && !validToken) {
            return <Auth />            
        }
        else {
            return false
        }
    }
}

const mapStateToProps = state => ({ auth: state.auth })
const mapDispatchToProps = dispatch => bindActionCreators({ valiteTokenRequest }, dispatch)
export default connect(mapStateToProps, mapDispatchToProps)(Authentication)      

