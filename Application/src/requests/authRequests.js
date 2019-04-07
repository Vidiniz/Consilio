import axios from 'axios';
import { toastr } from 'react-redux-toastr';

export const authenticationRequest = value => {
    return dispatch => {
        axios.post('http://localhost:5000/api/authentication', value)
            .then(response => {
                dispatch({ type: 'TOKEN_VALIDATED', payload: response.data.valid })
            })
            .catch(error => {
                dispatch({ type: 'TOKEN_VALIDATED', payload: false })
            })
    }
}

export const defautlRequest = (dataUrl, value) => {
    return dispatch => {
        axios.post(`http://localhost:5000/api/${dataUrl}`, value)
            .then(response => {
                dispatch([
                    { type: 'USER_FETCHED', payload: response.data }
                ])
            })
            .catch(error => {
                toastr.error('Erro', error.response.data.errors)
            })
    }
}
