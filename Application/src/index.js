import './utils/dependencies';
import React from 'react';
import ReactDOM from 'react-dom';
import * as serviceWorker from './serviceWorker';
import { applyMiddleware, createStore} from 'redux';
import { Provider } from 'react-redux';
import promise from 'redux-promise';
import multi from 'redux-multi';
import thunk from 'redux-thunk';
import reducers from './reducers/reducer';
import Authentication from './authentication/authentication';
// import App from './main/app';
// import Auth from './authentication/auth';

const devTools = window.__REDUX_DEVTOOLS_EXTENSION__ 
      && window.__REDUX_DEVTOOLS_EXTENSION__();
const store = applyMiddleware(multi, thunk, promise)(createStore)(reducers, devTools);

ReactDOM.render(    
    <Provider store={store}>
        <Authentication />
    </Provider>
    ,document.getElementById('root'));

serviceWorker.unregister();
