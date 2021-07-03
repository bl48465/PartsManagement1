import React from 'react';
import WidgetSm from '../components/Tables/WidgetSm';
import FeaturedInfo from '../components/Tables/FeaturedInfo';
import "../components/Tables/featuredInfo.css";
import "../components/Tables/widgetSm.css";


function Home() {
  return (
    <div className='home'>
      <FeaturedInfo/>
       <WidgetSm />
    </div>
  );
}



export default Home;