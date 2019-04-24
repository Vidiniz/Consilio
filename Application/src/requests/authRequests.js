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
                    if (e.name === 'TypeError') {
                        toastr.error('Erro', `Acesso negado ao Servidor!`)
                    }
                    else {
                        toastr.error('Erro', `${e.name} - ${e.message}`)
                    }
                }
            })
    }
}

export const validateToken = value => {    
    return defautlRequest('ValidateToken', value);
}

const defautlRequest = (dataUrl, value) => {
    return dispatch => {
        axios.post(`http://localhost:5000/api/Authentication/${dataUrl}`, value)
            .then(response => {
                dispatch([
                    { type: 'TOKEN_VALIDATED', payload: response.data }
                ])
            })
            .catch(error => {
                try {
                    toastr.error('Erro', error.response.data.errors)
                }
                catch (e) {
                    if (e.name === 'TypeError') {
                        toastr.error('Erro', `Acesso negado ao Servidor!`)
                    }
                    else {
                        toastr.error('Erro', `${e.name} - ${e.message}`)
                    }
                }
            })
    }
}
