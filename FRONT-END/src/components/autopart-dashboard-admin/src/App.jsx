import React from 'react';
import './App.css';
import Navbar from './components/Navbar';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import Home from './pages/Home';
import Support from './pages/Support';
import Settings from './pages/Settings';
import Messages from './pages/Messages';
import Users from './pages/Users';


function AppJs() {
  return (
    <>
      <Router>
        <Navbar />
        <Switch>
          <Route path='/AdminPanel' exact component={Home} />
          <Route path='/support' component={Support} />
          <Route path='/settings' component={Settings} />
          <Route path='/Mesazhet' component={Messages} />
          <Route path='/Përdoruesit' component={Users} />
        </Switch>
      </Router>
    </>
  );
}

export default AppJs;