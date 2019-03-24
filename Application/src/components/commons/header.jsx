import React from 'react';
import Navbar from './navbar';

export default props => (
    <header className="main-header">
        <a href="/#/" className="logo">
            <span className="logo-mini">
                <i class="fa fa-shield"></i>
            </span>
            <span className="logo-lg">
                <i class="fa fa-shield"></i>
                <b> Project</b> Base
            </span>
        </a>
        <nav className="navbar navbar-static-top">
            <a href="/#/" className="sidebar-toggle" data-toggle="push-menu" role="button"></a>
            <Navbar />
        </nav>
    </header>
)