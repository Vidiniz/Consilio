import React, {Component} from 'react';
import { connect } from 'react-redux';

class TabContent extends Component {
    render() {
        let selected = false;
        let visible = false;
        if (this.props.tab !== undefined) {
            selected = this.props.tab.selected === this.props.id;
            visible = this.props.tab.visible[this.props.id];        
        }
        if(visible) {
            return(            
                <div id={this.props.id} 
                     className={`tab-pane ${selected ? 'active': ''}`}>
                     {this.props.children}
                </div>
            )
        }
        else 
            return false        
    }
}

const mapStateToProps = state => ({tab: state.tab})
export default connect(mapStateToProps)(TabContent)