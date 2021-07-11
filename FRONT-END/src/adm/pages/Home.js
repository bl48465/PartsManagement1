import React from 'react';
import WidgetSm from '../components/Tables/WidgetSm';
import FeaturedInfo from '../components/Tables/FeaturedInfo';
import "../components/Tables/featuredInfo.css";
import "../components/Tables/widgetSm.css";
import NavbarAdmin from '../components/Navbar';


function HomeAdmin() {
  return (
    <div className='home'>
      <NavbarAdmin/>
      <FeaturedInfo/>
       <WidgetSm />
    </div>
  );
}



export default HomeAdmin;