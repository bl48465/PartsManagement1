import React from 'react';
import './App.css';
import Navbar from './components/Navbar';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import Home from './pages/Home';
import Komente from './pages/Komente';
import Sektoret from './pages/Sektoret';
import Support from './pages/Support';
import Settings from './pages/Settings';
import Porosite from './pages/Porosite';
import Furnitori from './pages/Furnitori';
import AddKerkesaTable from './components/Tables/AddKerkesaT';

function App() {
  return (
    <>
      <Router>
        <Navbar />
        <Switch>
          <Route path='/' exact component={Home} />
          <Route path='/Komente' component={Komente} />
          <Route path='/Porosite' component={Porosite} />
          <Route path='/Furnitori' component={Furnitori} />
          <Route path='/Sektoret' component={Sektoret} />
          <Route path='/support' component={Support} />
          <Route path='/Kerkesa' component={AddKerkesaTable} />
          <Route path='/settings' component={Settings} />
        </Switch>
      </Router>
    </>
  );
}

export default App;