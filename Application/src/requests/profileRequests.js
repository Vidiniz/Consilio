import axios from 'axios';
import { toastr } from 'react-redux-toastr';

const BASE_URL = 'http://localhost:5000/api/systemprofile';

export const getAll = () => {
    let request;
    
    try {
       request  = axios.get(`${BASE_URL}/obtertodos`);
       return {
        type: 'PROFILE_FETCHED',
        payload: request
        }   
    }
    catch(e) {
        toastr.error(e.name,e.message);
    }    
}

export const saveProfile = (value, parameter) => {
    return dispatch => {
        axios.post(`${BASE_URL}/salvarperfil`,value)
        .then(() => {
            try {
                toastr.success('Sucesso', 'Registro salvo com sucesso !')
                dispatch(parameter)
            }
            catch(e) {
                toastr.error(e.name, e.message);
            }
        })
        .catch(error => {
            toastr.error('Erro',error.data.error);
        })
    }    
}

export const updateProfile = (value, id, parameter) => {
    return dispatch => {
        axios.put(`${BASE_URL}/alterarperfil&id=${id}`,value)
        .then(() => {
            try {
                toastr.success('Sucesso', 'Registro salvo com sucesso !')
                dispatch(parameter)
            }
            catch(e) {
                toastr.error(e.name, e.message);
            }
        })
        .catch(error => {
            toastr.error('Erro',error.data.error);
        })
    }    
}

export const removeProfile = (id, parameter) => {
    return dispatch => {
        axios.delete(`${BASE_URL}/RemoverPerfil&id=${id}`)
        .then(() => {
            try {
                toastr.success('Sucesso', 'Registro removido com sucesso !')
                dispatch(parameter)
            }
            catch(e) {
                toastr.error(e.name, e.message);
            }
        })
        .catch(error => {
            toastr.error('Erro',error.data.error);
        })
    }    
}