import React, { Component } from 'react';
import { validateToken } from '../actions/authAction';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import axios from 'axios';
import Auth from './auth';
import App from '../main/app';

class Authentication extends Component {
    componentWillMount() {
        // TODO: Remover console
        console.log(this.props);
        
        if (this.props.user) {            
            this.props.validateToken(this.props.auth.user.token)
        }
    }

    render() {        
        const { user, validToken } = this.props.auth
        if (user && validToken) {
            axios.defaults.headers.common['authorization'] = user.token
            return <App/>
        } else if (!user && !validToken) {
            return <Auth />
        } else {
            return false
        }
    }
}
const mapStateToProps = state => ({ auth: state.auth })
const mapDispatchToProps = dispatch => bindActionCreators({ validateToken }, dispatch)
export default connect(mapStateToProps, mapDispatchToProps)(Authentication)