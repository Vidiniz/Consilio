import { combineReducers } from 'redux';
import { reducer as formReducer } from 'redux-form';
import { reducer as toastrReducer } from 'react-redux-toastr';
import AuthReducer from './authReducer';

const rootReducer = combineReducers({
    toastr: toastrReducer,
    form: formReducer,
    auth: AuthReducer
})

export default rootReducer