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



const AppContainer = styled.div `
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
`;

function App() {
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

              <Route path = "/Produkti" >
              <AppContainer >
              <Navbar / >
              <ProduktiTable / >
              </AppContainer> 
              </Route>

              <Route path = "/Sektori" >
              <AppContainer >
              <Navbar />
              <SektoriTable />
              </AppContainer> 
              </Route>

              <Route path = "/Komenti" >
              <AppContainer >
              <Navbar />
              <KomentiTable />
              </AppContainer> 
              </Route> 

              <Route path = "/Porosite" >
              < AppContainer >
              <Navbar />
              < PorositeTable />
              </AppContainer> 
              </Route>
              
              <Route path = "/Furnitori" >
              <AppContainer >
              < Navbar />
              <FurnitoriTable />
              </AppContainer> 
              </Route> 
            </Switch>
          </div> 
    </BrowserRouter>
    );
}

export default App;