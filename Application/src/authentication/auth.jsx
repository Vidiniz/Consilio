import React, { Component } from 'react';
import { reduxForm, Field } from 'redux-form';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import Input from '../components/commons/inputAuth';
import { login } from '../actions/authAction';

class Auth extends Component {
    componentWillMount() {
        document.body.classList.add('login-page')
    }

    componentWillUnmount() {
        document.body.classList.remove('login-page');
    }

    changeMode() {
        this.setState({ loginMode: !this.state.loginMode })
    }

    onSubmit(values) {
        const { login } = this.props;
        login(values);
    }

    render() {
        const { handleSubmit } = this.props
        return (
            <div className="login-page">
                <div className="login-box">
                    <div className="login-logo"><b>Consilio</b> Project</div>
                    <div className="login-box-body">
                        <p className="login-box-msg">Efetue login</p>
                        <form onSubmit={handleSubmit(v => this.onSubmit(v))}>
                            <Field component={Input} type="input" name="user"
                                placeholder="E-mail" icon="glyphicon glyphicon-user" maxLength="50" />
                            <Field component={Input} type="password" name="password"
                                placeholder="Senha" icon="glyphicon glyphicon-lock" maxLength="20" />
                            <div className="row">
                                <div className="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                                    <a href="#">Recuperar senha</a>
                                </div>
                                <div className="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                                    <button
                                        type="submit"
                                        className="btn btn-primary btn-block btn-flat">
                                        Entrar
                                    </button>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        )
    }
}

Auth = reduxForm({ form: 'authForm' })(Auth);
const mapDispatchToProps = dispatch => bindActionCreators({ login }, dispatch)
export default connect(null, mapDispatchToProps)(Auth)