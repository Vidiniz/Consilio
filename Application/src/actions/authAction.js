import { authenticationRequest, defautlRequest } from '../requests/authRequests';

export const login = values => {
    return defautlRequest('Authentication', values)
} 

export const validateToken = token => {
    if (token) {
        return authenticationRequest(token)
    }
    else {
        return dispatch => ({ type: 'TOKEN_VALIDATED', payload: false }) 
    }
}