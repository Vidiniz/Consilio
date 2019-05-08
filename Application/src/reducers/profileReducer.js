const INITIAL_STATE = {list: []}

export default (state = INITIAL_STATE, action) => {
    switch (action.type) {
        case 'PROFILE_FETCHED':
            return { ...state, list: action.payload.data }
        case 'UNIQUE_PROFILE_FETCHED':
            return { ...state, profile: action.payload.data}
        default:
            return state
    }
}