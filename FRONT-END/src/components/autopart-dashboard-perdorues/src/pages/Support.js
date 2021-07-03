import React from 'react';
import * as RiIcons from 'react-icons/ri';
import { IconContext } from 'react-icons';

function Support() {
  return (
    <IconContext.Provider value={{ color: 'FC4747' , size: '30%'}}>
   <div class="help">
      <h1 class='help-h1'>Përshendetje, keni nevojë për ndihmë?</h1>
      <div class='help-content'>
        <div class='help-container1'>
           <div class='card1'>
              <RiIcons.RiCloseCircleFill/>
              <h3>Rregullo një problem</h3>
              <p>Nëse keni hasur probleme gjatë përdorimit të softuerit</p>
              <button class='help-btn'>Mëso më shumë</button>
           </div>
          <div class='card2'>
          <RiIcons.RiAccountCircleFill/>
            <h3>Llogaria juaj</h3>
            <p>Nëse doni të kuptoni se cfarë ju ofron qasja në llogari</p>
            <button class='help-btn' >Mëso më shumë</button>
          </div>
        </div>
        
        <div class='help-container2'>
          <div class='card1'>
          <RiIcons.RiSecurePaymentFill/>
            <h3>Pagesat dhe faturimi</h3>
            <p>Nëse doni të mësoni më shumë në lidhje me pagesat</p>
            <button class='help-btn'>Mëso më shumë</button>
          </div>

          <div class='card2'>
          <RiIcons.RiQuestionFill/>
            <h3>Pyetjet më të shpeshta</h3>
            <p>Pyetjet më të shpeshta nga përdoruesit</p>
            <button class='help-btn' >Mëso më shumë</button>
          </div>
        </div>
      
      </div>
   </div>
   </IconContext.Provider>
  );
}

export default Support;
