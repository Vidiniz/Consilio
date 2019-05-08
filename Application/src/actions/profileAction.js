import { initialize } from 'redux-form';
import { showTabs, selectTab } from '../actions/tabAction';
import { getAll, getProfileById, saveProfile, updateProfile, removeProfile, getProfileByIdAsync } from '../requests/profileRequests';

const INITIAL_VALUES = {};

export const getList = () => {
    return getAll()
}

export const getById = id =>{
    return getProfileById(id)
}

export const create = values => {
    return saveProfile(values, init())
}

export const update = (values) => {
    return updateProfile(values, init())
}

export const remove = profile => {
    return removeProfile(profile.id, init())
}

export const showUpdate = profile => {    
    let result = getProfileByIdAsync(profile.id)
    .then(response => response.data);    
    return [ 
        showTabs('tabUpdate'),
        selectTab('tabUpdate'),
        initialize('profileForm', result)
    ]
}

export const showDelete = profile => {
    let result = getProfileByIdAsync(profile.id)
    .then(response => response.data);    
    return [ 
        showTabs('tabDelete'),
        selectTab('tabDelete'),
        initialize('profileForm',result)
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