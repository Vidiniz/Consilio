import React, { Component } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { reduxForm, Field } from 'redux-form';
import { init } from '../../../actions/profileAction';
import ContainerInput from '../../commons/containerInput';
import ContainerCheckbox from '../../commons/containerCheckbox';

class ProfileForm extends Component {
    render() {
        const { handleSubmit, readOnly } = this.props;
        return (
            <form onSubmit={handleSubmit}>
                <div className="box-body">
                    <div className="row">
                        <Field name="name" component={ContainerInput} readOnly={readOnly}
                            label="Descrição" cols="col-xs-12 col-sm-12 col-md-6 col-lg-6"
                            placeholder="Nome do Perfil" type="text" maxLength="80" />
                    </div>
                    <div className="row">
                        '   <Field name="hasadmin" component={ContainerCheckbox} readOnly={readOnly}
                            label="Usuário Administrador" cols="col-xs-12 col-sm-12 col-md-6 col-lg-6"
                            type="checkbox" />
                    </div>
                </div>
                <div className="box-footer">
                    <button type="submit" className={this.props.submitClass}>
                        {this.props.submitLabel}
                    </button>
                    <button type="button"
                        className="btn btn-default"
                        onClick={this.props.init}>
                        Cancelar
                    </button>
                </div>
            </form>
        )
    }
}

ProfileForm = reduxForm({ form: 'profileForm', destroyOnUnmount: false })(ProfileForm)
const mapStateToProps = state => ({ profile: state.profile })
const mapDispatchToProps = dispatch => bindActionCreators({ init }, dispatch)
export default connect(mapStateToProps, mapDispatchToProps)(ProfileForm)