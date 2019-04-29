import React, {Component} from 'react';
import ContentHeader from '../commons/contentHeader';
import ContentBody from '../commons/contentBody';
import Box from '../commons/box';
import Tabs from '../commons/tab/tabs';
import TabsHeader from '../commons/tab/tabsHeader';
import TabHeader from '../commons/tab/tabHeader';

class Profile extends Component {
    render() {
        return(
            <div>
                <ContentHeader title="Sistema" small="v 1.00"/>
                <ContentBody>
                    <Box title="Perfis">
                        <Tabs>
                            <TabsHeader>
                                <TabHeader label="Listar" icon="fa fa-bars" />
                                <TabHeader label="Incluir" icon="fa fa-plus" />
                                <TabHeader label="Alterar" icon="fa fa-pencil" />
                                <TabHeader label="Excluir" icon="fa fa-trash-o" />
                            </TabsHeader>
                        </Tabs>
                    </Box>
                </ContentBody>
            </div>
        )
    }
}

export default Profile;