import React from 'react';
import './App.css';
import Navbar from './components/Navbar';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import Home from './pages/Home';
import Komente from './pages/Komente';
import Support from './pages/Support';
import Settings from './pages/Settings';
import Porosite from './pages/Porosite';
import Shitjet from './pages/Shitjet';
import Produktet from './pages/Produktet';
import AddKerkesaTable from './components/Tables/AddKerkesaT';

function PuntoriApp() {
  return (
    <>
      <Router>
        <Navbar />
        <Switch>
          <Route path='/PuntoriPanel' exact component={Home} />
          <Route path='/Komente' component={Komente} />
          <Route path='/Porosite' component={Porosite} />
          <Route path='/Support' component={Support} />
          <Route path='/Kerkesa' component={AddKerkesaTable} />
          <Route path='/Settings' component={Settings} />
          <Route path='/Shitjet' component={Shitjet} />
          <Route path='/Produktet' component={Produktet} />
        </Switch>
      </Router>
    </>
  );
}

export default PuntoriApp;