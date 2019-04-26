import React from 'react';
import MenuItem from './menuItem';
import MenuTree from './menuTree';

export default props => (
    <ul className="sidebar-menu tree" data-widget="tree">
        <MenuItem path="/" label="Home" icon="fa fa-home" />
        <MenuTree path="/" label="Sistema" icon="fa fa-edit">
            <MenuItem path="profile" label="Perfil" icon="fa fa-circle-o"/>
            <MenuItem path="user" label="Usuário" icon="fa fa-circle-o"/>
        </MenuTree>    
    </ul>
)
    