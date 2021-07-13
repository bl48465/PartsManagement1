import "./App.css";
import styled from "styled-components";
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import { AccountBox } from './components/accountBox/index';
import { Homepage } from './containers/homepage/index';
import UserApp from "./components/user/userindex";
import { ProduktiTable } from '././components/user/Produkti'
import { SektoriTable } from '././components/user/Sektori'
import { KomentiTable } from '././components/user/Komenti';
import { PorositeTable } from '././components/user/Porosia';
import { FurnitoriTable } from '././components/user/Furnitoret';
import { useSelector } from "react-redux";
import { ProtectedRoute } from "./features/ProtectedRoute";
import React from 'react'
import { Logout } from "./components/accountBox/Logout";
import { selectUser } from "./reducers/rootReducer";
import { NotFound } from "./NotFound";
import { ShitjaTable } from './components/user/Shitja';
import { StokuTable } from './components/user/Stoku';
import { PuntoriTable } from './components/user/Puntori';
import { AdminTable } from "./components/user/admin/Admin";
import Dankmemes from "./components/user/Chart";
import { ContactUs } from "./containers/homepage/contactUs";
import { ContactTable } from "./components/user/ContactUs";


const AppContainer = styled.div `
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
`;

function App() {
    const user = useSelector(selectUser);

    return ( <
        BrowserRouter >
        <
        div className = "Container" >
        <
        Switch >
        <
        Route exact path = "/" >
        <
        Homepage / >
        <
        /Route>

        <
        Route path = "/ContactAdmin" >


        <
        ContactTable / >
        <
        /
        Route >

        <
        Route path = "/AccountBox" >
        <
        AppContainer >
        <
        AccountBox / >
        <
        /AppContainer> < /
        Route >




        <
        ProtectedRoute path = "/Home"
        role = { user === null ? '' : user.roli }
        component = { Dankmemes }
        isAuth = { user === null ? false : true }
        />  <
        ProtectedRoute path = "/Produkti"
        role = { user === null ? '' : user.roli }
        component = { ProduktiTable }
        isAuth = { user === null ? false : true }
        /> <
        ProtectedRoute path = "/Komenti"
        role = { user === null ? '' : user.roli }
        component = { KomentiTable }
        isAuth = { user === null ? false : true }
        /> <
        ProtectedRoute path = "/Sektori"
        role = { user === null ? '' : user.roli }
        component = { SektoriTable }
        isAuth = { user === null ? false : true }
        /> <
        ProtectedRoute path = "/Porosite"
        role = { user === null ? '' : user.roli }
        component = { PorositeTable }
        isAuth = { user === null ? false : true }
        /> <
        ProtectedRoute path = "/Logout"
        role = { user === null ? '' : user.roli }
        component = { Logout }
        isAuth = { user === null ? false : true }
        /> <
        ProtectedRoute path = "/Furnitori"
        role = { user === null ? '' : user.roli }
        component = { FurnitoriTable }
        isAuth = { user === null ? false : true }
        /> <
        ProtectedRoute path = "/Settings"
        role = { user === null ? '' : user.roli }
        component = { UserApp }
        isAuth = { user === null ? false : true }
        /> <
        ProtectedRoute path = "/Stoku"
        role = { user === null ? '' : user.roli }
        component = { StokuTable }
        isAuth = { user === null ? false : true }
        /> <
        ProtectedRoute path = "/Shitja"
        role = { user === null ? '' : user.roli }
        component = { ShitjaTable }
        isAuth = { user === null ? false : true }
        /> <
        ProtectedRoute path = "/Puntori"
        role = { user === null ? '' : user.roli }
        component = { PuntoriTable }
        isAuth = { user === null ? false : true }
        /> {
        /*               
                      <ProtectedAdmin path="/HomeAdmin" role={user===null?'':user.roli} component={HomeAdmin} isAuth={user===null?false:true}/>
                      <ProtectedAdmin path="/SupportAdmin" role={user===null?'':user.roli} component={SupportAdmin} isAuth={user===null?false:true}/>
                      <ProtectedAdmin path="/MessagesAdmin" role={user===null?'':user.roli} component={MessagesAdmin} isAuth={user===null?false:true}/>
                      <ProtectedAdmin path="/UsersAdmin" role={user===null?'':user.roli} component={UsersAdmin} isAuth={user===null?false:true}/>
                      <ProtectedAdmin path="/SettingsAdmin" role={user===null?'':user.roli} component={SettingsAdmin} isAuth={user===null?false:true}/>  

                      <ProtectedPuntor path="/HomePuntori" role={user===null?'':user.roli} component={SettingsAdmin} isAuth={user===null?false:true}/> 
                      <ProtectedPuntor path="/KomentePuntori" role={user===null?'':user.roli} component={SettingsAdmin} isAuth={user===null?false:true}/> 
                      <ProtectedPuntor path="/PorositePuntori" role={user===null?'':user.roli} component={SettingsAdmin} isAuth={user===null?false:true}/> 
                      <ProtectedPuntor path="/ProduktetPuntori" role={user===null?'':user.roli} component={SettingsAdmin} isAuth={user===null?false:true}/> 
                      <ProtectedPuntor path="/SettingsPuntori" role={user===null?'':user.roli} component={SettingsAdmin} isAuth={user===null?false:true}/> 
                      <ProtectedPuntor path="/SupportPuntori" role={user===null?'':user.roli} component={SettingsAdmin} isAuth={user===null?false:true}/>  */
    }

    <
    Route path = "/NotFound" >
        <
        NotFound / >
        <
        /Route>


    <
    /Switch> < /
    div > <
        /BrowserRouter>
);
}

export default App;