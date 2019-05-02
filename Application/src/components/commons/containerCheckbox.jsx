import React from 'react';

export default props => (
    <div className={props.cols}>
        <div className="form-group">            
            <div className="checkbox">
                <label htmlFor={props.name}>
                    <input {...props.input} 
                        readOnly={props.readOnly}
                        type={props.type}
                        name={props.name}/>
                    {props.label}
                </label>                
            </div>            
        </div>
    </div>
)