import "./App.css";
import styled from "styled-components";
import {BrowserRouter,Switch,Route} from 'react-router-dom';
import { AccountBox } from './components/accountBox/index';
import { Homepage } from './containers/homepage/index';
import Home from "./components/accountBox/loginSuccess";
import AppJs from "./components/autopart-dashboard-admin/src/App";
import UserApp from "./components/autopart-dashboard-perdorues/src/App";
import PuntoriApp from "./components/autopart-profile-puntore/src/App";


const AppContainer = styled.div`
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
`;

function App() {
  return (
    <BrowserRouter>
    <div className="Container">
      <Switch>
      <Route exact path="/">
        <Homepage/>
      </Route>
      <Route path="/AccountBox">
          <AppContainer>
          <AccountBox />
          </AppContainer>
          </Route>
          <Route path="/Dashboard">
          <Home />
          </Route>
          <Route path="/AdminPanel">
          <AppJs />
          </Route>
          <Route path="/UserPanel">
          <UserApp />
          </Route>
          <Route path="/PuntoriPanel">
          <PuntoriApp />
          </Route>
        </Switch>
      </div> 
      </BrowserRouter>
  );
}

export default App;
