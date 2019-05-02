import { initialize } from 'redux-form';
import { showTabs, selectTab } from '../actions/tabAction';
import { getAll, getProfileById, saveProfile, updateProfile, removeProfile } from '../requests/profileRequests';

const INITIAL_VALUES = {};

export const getList = () => {
    return getAll()
}

export const getById = id =>{
    return getProfileById(id)
}

export const create = values => {
    return saveProfile(values, init)
}

export const update = (values, id) => {
    return updateProfile(values, id, init)
}

export const remove = id => {
    return removeProfile(id, init)
}

export const showUpdate = profile => {        
    return [ 
        showTabs('tabUpdate'),
        selectTab('tabUpdate'),
        initialize('profileForm', getById(profile.id))
    ]
}

export const showDelete = profile => {
    return [ 
        showTabs('tabDelete'),
        selectTab('tabDelete'),
        initialize('profileForm', getById(profile.id))
    ]
}

export const init = () => {
    return [
        showTabs('tabList', 'tabCreate'),
        selectTab('tabList'),
        getList(),
        initialize('profileForm', INITIAL_VALUES)
    ]
}