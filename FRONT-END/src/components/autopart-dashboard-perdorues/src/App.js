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
import Shitjet from './pages/Shitjet';
import Produktet from './pages/Produktet';
import AddKerkesaTable from './components/Tables/AddKerkesaT';
<<<<<<< Updated upstream:FRONT-END/src/components/autopart-dashboard-perdorues/src/App.js
import Punetoret from './pages/Punetoret';
=======
import Produkti from './components/Tables/Produkti';
>>>>>>> Stashed changes:LoggedinUser/src/App.js

function UserApp() {
  return (
    <>
      <Router>
        <Navbar />
        <Switch>
          <Route path='/UserPanel' exact component={Home} />
          <Route path='/Komente' component={Komente} />
          <Route path='/Porosite' component={Porosite} />
          <Route path='/Furnitori' component={Furnitori} />
          <Route path='/Sektoret' component={Sektoret} />
<<<<<<< Updated upstream:FRONT-END/src/components/autopart-dashboard-perdorues/src/App.js
          <Route path='/Ndihma' component={Support} />
=======
          <Route path='/support' component={Support} />
          <Route path='/produktet' component={Produkti} />
>>>>>>> Stashed changes:LoggedinUser/src/App.js
          <Route path='/Kerkesa' component={AddKerkesaTable} />
          <Route path='/settings' component={Settings} />
          <Route path='/Shitjet' component={Shitjet} />
          <Route path='/Produktet' component={Produktet} />
          <Route path='/Punetoret' component={Punetoret} />
        </Switch>
      </Router>
    </>
  );
}

export default UserApp;