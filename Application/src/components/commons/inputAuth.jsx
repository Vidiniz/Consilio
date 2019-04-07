import React from 'react';

export default props => {
        return (
            <div className="form-group has-feedback">
                <input
                    {...props.input}
                    className="form-control"
                    placeholder={props.placeholder}
                    readOnly={props.readOnly}
                    type={props.type}
                />
                <span className={`${props.icon} form-control-feedback`}></span>
            </div>
        )    
}