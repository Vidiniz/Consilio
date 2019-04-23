import { authenticationRequest, validateToken } from '../requests/authRequests';

export const login = values => {
    return authenticationRequest(values);
} 

export const logout = () => {
    return { type: 'TOKEN_VALIDATED', payload: false }
}

export const valiteTokenRequest = token => {
    if (token) {
        return validateToken({ token : token })      
    }
    else {
        return dispatch => ({ type: 'TOKEN_VALIDATED', payload: false }) 
    }
}