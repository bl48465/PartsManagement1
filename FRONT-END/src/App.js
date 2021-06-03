import "./App.css";
import styled from "styled-components";
import {BrowserRouter,Switch,Route} from 'react-router-dom';
import { AccountBox } from './components/accountBox/index';
import { Homepage } from './containers/homepage/index';

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
        </Switch>
      </div> 
      </BrowserRouter>
  );
}

export default App;
