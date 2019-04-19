import React, { Component } from 'react';
import { toastr } from 'react-redux-toastr';

export default class TestComponent extends Component {
    render() {
        return (
            <div>
                <button
                    onClick={() => toastr.success('teste', 'teste')}
                    type="button">Toastr Success</button>
            </div>
        )
    }
}