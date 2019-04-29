import { reset as resetForm, initialize } from 'redux-form';
import { showTabs, selectTab } from '../actions/tabAction';
import { getAll } from '../requests/profileRequests';

const INITIAL_VALUES = {};

export const getList = () => {
    return getAll()
}

export function create(values) {
    return submit(values, 'post')
}

export function update(values) {
    return submit(values, 'put')
}

export function remove(values) {
    return submit(values, 'delete')
}

export const showUpdate = profile => {
    return [ 
        showTabs('tabUpdate'),
        selectTab('tabUpdate'),
        initialize('profileForm', profile)
    ]
}

export const showDelete = profile => {
    return [ 
        showTabs('tabDelete'),
        selectTab('tabDelete'),
        initialize('profileForm', profile)
    ]
}

export function init() {
    return [
        showTabs('tabList', 'tabCreate'),
        selectTab('tabList'),
        getList(),
        initialize('profileForm', INITIAL_VALUES)
    ]
}