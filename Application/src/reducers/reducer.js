import { combineReducers } from 'redux';
import { reducer as formReducer } from 'redux-form';
import { reducer as toastrReducer } from 'react-redux-toastr';
import AuthReducer from './authReducer';
import TabReducer from './tabReducer';
import ProfileReducer from './profileReducer';

const rootReducer = combineReducers({
    profile: ProfileReducer,
    tab: TabReducer,
    toastr: toastrReducer,
    form: formReducer,
    auth: AuthReducer
})

export default rootReducer