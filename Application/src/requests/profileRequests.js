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

export const saveProfile = value => {
    return dispatch => {
        axios.post(`${BASE_URL}/salvarperfil`,value)
        .then(response => {
            toastr.success('Sucesso', 'Registro salvo com sucesso !')
            dispatch(init())
        })
    }    
}