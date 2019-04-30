import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import ContentHeader from '../../commons/container/contentHeader';
import ContentBody from '../../commons/container/contentBody';
import Box from '../../commons/container/box';
import Tabs from '../../commons/tab/tabs';
import TabsHeader from '../../commons/tab/tabsHeader';
import TabHeader from '../../commons/tab/tabHeader';
import TabsContent from '../../commons/tab/tabsContent';
import TabContent from '../../commons/tab/tabContent';
import { init, create, update, remove } from '../../../actions/profileAction';
import ProfileList from './profileList';

class Profile extends Component {
    componentWillMount() {
        this.props.init();
    }

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
                                    <ProfileList />
                                </TabContent>
                                <TabContent id="tabCreate">
                                    Inserir
                                </TabContent>
                                <TabContent id="tabUpdate">
                                    Altear
                                </TabContent>
                                <TabContent id="tabDelete">
                                    Excluir
                                </TabContent>
                            </TabsContent>
                        </Tabs>
                    </Box>
                </ContentBody>
            </div>
        )
    }
}

const mapDispatchToProps = dispatch => bindActionCreators({ init, create, update, remove }, dispatch)
export default connect(null, mapDispatchToProps)(Profile)