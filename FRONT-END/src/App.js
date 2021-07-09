import "./App.css";
import styled from "styled-components";
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import { AccountBox } from './components/accountBox/index';
import { Homepage } from './containers/homepage/index';
import Home from "./components/accountBox/loginSuccess";
import UserApp from "./components/user/userindex";
import { ProduktiTable } from '././components/user/Produkti'
import { SektoriTable } from '././components/user/Sektori'
import { KomentiTable } from '././components/user/Komenti';
import { PorositeTable } from '././components/user/Porosia';
import { FurnitoriTable } from '././components/user/Furnitoret';
import Navbar from '././components/user/navbar/Navbar';
import { useSelector } from "react-redux";
import { ProtectedRoute } from "./features/ProtectedRoute";
import React,{useState} from 'react'
import { Logout } from "./components/accountBox/Logout";
import { selectUser } from "./reducers/rootReducer";
import { selectCurrentLog } from "./reducers/logReducer";
import UserCard from "./components/user/Useri";
import Form from "./components/user/KerkesaComponent/Form";




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
  const log = useSelector(selectCurrentLog)

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

              <ProtectedRoute path="/Produkti" component={ProduktiTable} isAuth={user===null?false:true}/>
              <ProtectedRoute path="/Komenti" component={KomentiTable} isAuth={user===null?false:true}/>
              <ProtectedRoute path="/Sektori" component={SektoriTable} isAuth={user===null?false:true}/>
              <ProtectedRoute path="/Porosite" component={PorositeTable} isAuth={user===null?false:true}/>
              <ProtectedRoute path="/Logout" component={Logout} isAuth={user===null?false:true}/>
              <ProtectedRoute path="/Furnitori" component={FurnitoriTable} isAuth={user===null?false:true}/>
              <ProtectedRoute path="/Settings" component={UserCard} isAuth={user===null?false:true}/>
              <ProtectedRoute path="/Kerkesa" component={Form} isAuth={user===null?false:true}/>



        




            </Switch>
          </div> 
    </BrowserRouter>
    );
}

export default App;