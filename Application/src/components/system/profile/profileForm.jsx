import React, { Component } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { reduxForm, Field} from 'redux-form';
import { init } from '../../../actions/profileAction';
import ContainerInput from '../../commons/containerInput';

class ProfileForm extends Component {
    render() {
        const { handleSubmit, readOnly } = this.props;
        return(
            <form onSubmit={handleSubmit}>
                <div className="box-body">
                    <Field name="Name" component={ContainerInput} readOnly={readOnly} 
                        label="Descrição" cols="col-xs-12 col-sm-12 col-md-6 col-lg-4" 
                        placeholder="Nome do Perfil" type="text"/>                    
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

ProfileForm = reduxForm({form: 'profileForm', destroyOnUnmount: false})(ProfileForm)
const mapDispatchToProps = dispatch => bindActionCreators({init}, dispatch)
export default connect(null, mapDispatchToProps)(ProfileForm)