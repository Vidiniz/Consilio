import axios from 'axios';
import { toastr } from 'react-redux-toastr';

export const authenticationRequest = value => {
        return dispatch => {
            axios.post('http://localhost:5000/api/Authentication/login', value)
                .then(response => {
                    dispatch({ type: 'USER_FETCHED', payload: response.data })
                })
                .catch(erro => {
                    try {
                        toastr.error('Acesso Negado', erro.response.data.login)                    
                    }
                    catch (e) {
                        toastr.error('Erro', `${e.name} - ${e.message}` )
                    }                  
                })
        }
}



export const defautlRequest = (dataUrl, value) => {
    return dispatch => {
        axios.post(`http://localhost:5000/api/${dataUrl}`, value)
            .then(response => {
                dispatch([
                    { type: 'TOKEN_VALIDATED', payload: response.data }
                ])
            })
            .catch(error => {
                toastr.error('Erro', error.response.data.errors)
            })
    }
}
