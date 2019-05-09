import React, { Component } from 'react'
import CheckBoxTree from 'react-checkbox-tree';

const nodes = [{
    value: 'mars',
    label: 'Mars',
    children: [
        { value: 'phobos', label: 'Phobos' },
        { value: 'deimos', label: 'Deimos' },
    ],
}];

class TreeViewCheckBox extends Component {  
    state = {
        checked: [],
        expanded: [],
    };

    constructor(props) {
        super(props);

        this.onCheck = this.onCheck.bind(this);
        this.onExpand = this.onExpand.bind(this);
    }

    // componentDidMount() {
        
    // }

    onCheck(checked) {        
        this.setState({ checked });
    }

    onExpand(expanded) {
        this.setState({ expanded });
    }

    render() {

        const { checked, expanded } = this.state;
        return (
            <CheckBoxTree
                checked={checked}
                expanded={expanded}
                nodes={nodes}
                onCheck={this.onCheck}
                onExpand={this.onExpand}
            />
        )
    }
}

export default TreeViewCheckBox;