import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import ContentHeader from '../commons/container/contentHeader';
import ContentBody from '../commons/container/contentBody';
import Box from '../commons/container/box';
import Tabs from '../commons/tab/tabs';
import TabsHeader from '../commons/tab/tabsHeader';
import TabHeader from '../commons/tab/tabHeader';
import TabsContent from '../commons/tab/tabsContent';
import TabContent from '../commons/tab/tabContent';

class Profile extends Component {
    render() {
        return (
            <div>
                <ContentHeader title="Sistema" small="v 1.00" />
                <ContentBody>
                    <Box title="Perfis" typebox="box-primary">
                        <Tabs>
                            <TabsHeader>
                                <TabHeader label="Listar" icon="fa fa-bars" target="tabList" />
                                <TabHeader label="Incluir" icon="fa fa-plus" target="tabCreate" />
                                <TabHeader label="Alterar" icon="fa fa-pencil" target="tabUpdate" />
                                <TabHeader label="Excluir" icon="fa fa-trash-o" target="tabDelete" />
                            </TabsHeader>
                            <TabsContent>
                                <TabContent id="tabList">
                                    teste
                                 </TabContent>
                            </TabsContent>
                        </Tabs>
                    </Box>
                </ContentBody>
            </div>
        )
    }
}

export default Profile;