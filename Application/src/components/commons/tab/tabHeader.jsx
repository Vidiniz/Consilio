import React, { Component } from 'react';

class TabHeader extends Component {

    render() {
        return (
            <li>
                <a href="javascript:;"
                    data-toggle="tab">
                    <i className={this.props.icon}></i>
                    {this.props.label}
                </a>
            </li>
        )
    }
}

export default TabHeader;