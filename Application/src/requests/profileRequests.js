import axios from 'axios';
import { toastr } from 'react-redux-toastr';

const BASE_URL = 'http://localhost:5000/api/systemprofile';

export const getAll = () => {
    let request;
    try {
        request = axios.get(`${BASE_URL}/obtertodos`);
        return {
            type: 'PROFILE_FETCHED',
            payload: request
        }
    }
    catch (e) {
        toastr.error(e.name, e.message);
    }
}

export const getProfileById = id => {
    let request;
    try {
        request = axios.get(`${BASE_URL}/obterporid?id=${id}`)
        return {
            type: 'UNIQUE_PROFILE_FETCHED',
            payload: request
        }
    }
    catch (e) {
        toastr.error(e.name, e.message);
    }
    // return dispatch => {
    //     axios.get(`${BASE_URL}/obterporid?id=${id}`)
    //         .then(response => dispatch({ type: 'UNIQUE_PROFILE_FETCHED', payload: response.data}))            
    //         .catch(error => toastr.error('Error',error));
    // }
}

export const getProfileByIdAsync = async id => {
    let request;
    try {
        request = await axios.get(`${BASE_URL}/obterporid?id=${id}`)
        return request        
    }
    catch (e) {
        toastr.error(e.name, e.message);
    }    
}

export const saveProfile = (value, parameter) => {
    return dispatch => {
        axios.post(`${BASE_URL}/salvarperfil`, value)
            .then(() => {
                try {
                    toastr.success('Sucesso', 'Registro salvo com sucesso !')
                    dispatch(parameter)
                }
                catch (e) {
                    toastr.error(e.name, e.message);
                }
            })
            .catch(error => {
                try {         
                    error.response.data !== undefined ? 
                        toastr.error('Erro', error.response.data.erros):
                        toastr.error(error.name, error.message);
                }
                catch(e){
                    toastr.error(e.name, e.message);
                }                
            })
    }
}

export const updateProfile = (value, parameter) => {
    return dispatch => {    
        axios.put(`${BASE_URL}/alterarperfil?id=${value.id}`, value)
            .then(() => {
                try {
                    toastr.success('Sucesso', 'Registro salvo com sucesso !')
                    dispatch(parameter)
                }
                catch (e) {
                    toastr.error(e.name, e.message);
                }
            })
            .catch(error => {
                try {         
                    error.response.data !== undefined ? 
                        toastr.error('Erro', error.response.data.erros):
                        toastr.error(error.name, error.message);
                }
                catch(e){
                    toastr.error(e.name, e.message);
                }                
            })
    }
}

export const removeProfile = (id, parameter) => {
    return dispatch => {
        axios.delete(`${BASE_URL}/RemoverPerfil?id=${id}`)
            .then(() => {
                try {
                    toastr.success('Sucesso', 'Registro removido com sucesso !')
                    dispatch(parameter)
                }
                catch (e) {
                    toastr.error(e.name, e.message);
                }
            })
            .catch(error => {
                try {         
                    error.response.data !== undefined ? 
                        toastr.error('Erro', error.response.data.erros):
                        toastr.error(error.name, error.message);
                }
                catch(e){
                    toastr.error(e.name, e.message);
                }                
            })
    }
}