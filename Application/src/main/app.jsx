import React, { Component } from 'react';
import { HashRouter } from 'react-router-dom';
import Header from '../components/commons/header';
import Sidebar from '../components/commons/sidebar';
import Footer from '../components/commons/footer';
import Routes from '../main/routes';

class App extends Component {
    render() {
        return (
            <HashRouter>
                <div className="wrapper">
                    <Header />                    
                    <Sidebar />  
                    <Routes />                  
                    <Footer />                    
                </div>
            </HashRouter>
        )
    }
}

export default App;