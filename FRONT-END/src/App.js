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
import Form from "./components/user/KerkesaComponent/Form";
import HomeAdmin from "./adm/pages/Home";
import SupportAdmin from "./adm/pages/Support";
import MessagesAdmin from "./adm/pages/Messages";
import UsersAdmin from "./adm/pages/Users";
import SettingsAdmin from "./adm/pages/Settings";
import { ProtectedAdmin } from "./features/ProtectedAdmin";
import { HomeUser } from "./components/user/Home";
import SupportUser from "./components/user/SupportUser";
import { ProtectedPuntor } from "./features/ProtectedPuntor";
import { NotFound } from "./NotFound";


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

    return (
    <BrowserRouter >
        <div className = "Container" >
            <Switch>
              <Route exact path = "/" >
              <Homepage />
              </Route>

              <Route path = "/AccountBox" >
              <AppContainer >
              <AccountBox />
              </AppContainer>
              </Route>

            

              <ProtectedRoute path="/HomeUser" role={user===null?'':user.roli} component={HomeUser} isAuth={user===null?false:true}/>
              <ProtectedRoute path="/Produkti" role={user===null?'':user.roli} component={ProduktiTable} isAuth={user===null?false:true}/>
              <ProtectedRoute path="/Komenti" role={user===null?'':user.roli} component={KomentiTable} isAuth={user===null?false:true}/>
              <ProtectedRoute path="/Sektori" role={user===null?'':user.roli} component={SektoriTable} isAuth={user===null?false:true}/>
              <ProtectedRoute path="/Porosite" role={user===null?'':user.roli} component={PorositeTable} isAuth={user===null?false:true}/>
              <ProtectedRoute path="/Logout" role={user===null?'':user.roli} component={Logout} isAuth={user===null?false:true}/>
              <ProtectedRoute path="/Furnitori" role={user===null?'':user.roli} component={FurnitoriTable} isAuth={user===null?false:true}/>
              <ProtectedRoute path="/Settings" role={user===null?'':user.roli} component={UserApp} isAuth={user===null?false:true}/>
              <ProtectedRoute path="/Kerkesa" role={user===null?'':user.roli} component={Form} isAuth={user===null?false:true}/>
              <ProtectedRoute path="/SupportUser" role={user===null?'':user.roli} component={SupportUser} isAuth={user===null?false:true}/>
              
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
              <ProtectedPuntor path="/SupportPuntori" role={user===null?'':user.roli} component={SettingsAdmin} isAuth={user===null?false:true}/> 

              <Route path = "/NotFound" >
              <NotFound/>
              </Route>


            </Switch>
          </div> 
    </BrowserRouter>
    );
}

export default App;