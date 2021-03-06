import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { selectTab } from '../../../actions/tabAction';

class TabHeader extends Component {
    render() {       
        const selected = this.props.tab.selected === this.props.target;
        const visible = this.props.tab.visible[this.props.target];                    
        if (visible) {
            return (
                <li className={selected ? 'active' : ''}>
                    <a href="javascript:;"
                        data-toggle="tab"
                        onClick={() => this.props.selectTab(this.props.target)}
                        data-target={this.props.target}>
                        <i className={this.props.icon}></i>
                        {this.props.label}
                    </a>
                </li>
            )
        }
        else
            return false
    }
}

const mapStateToProps = state => ({ tab: state.tab });
const mapDispatchToProps = dispatch => bindActionCreators({ selectTab }, dispatch);
export default connect(mapStateToProps, mapDispatchToProps)(TabHeader);