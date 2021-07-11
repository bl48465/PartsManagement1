import React from 'react';
import UserCard from '../components/Tables/Useri';
import NavbarAdmin from '../components/Navbar';

function SettingsAdmin() {
  return (
    <div className='SettingsAdmin'>
       <NavbarAdmin/>
    <UserCard/>
    </div>
  );
}

export default SettingsAdmin;