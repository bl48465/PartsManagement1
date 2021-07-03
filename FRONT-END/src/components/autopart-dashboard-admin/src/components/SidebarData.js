import React from 'react';
import * as FaIcons from 'react-icons/fa';
import * as AiIcons from 'react-icons/ai';
import * as IoIcons from 'react-icons/io';

export const SidebarData = [
  {
    title: 'Shtëpia',
    path: '/AdminPanel',
    icon: <AiIcons.AiFillHome className="iconn" />,
    cName: 'nav-text'
  },
  {
    title: 'Përdoruesit',
    path: '/Përdoruesit',
    icon: <FaIcons.FaUser className="iconn"/>,
    cName: 'nav-text'
  },
  

  {
    title: 'Mesazhet',
    path: '/Mesazhet',
    icon: <FaIcons.FaEnvelopeOpenText className="iconn"/>,
    cName: 'nav-text'
  },

  {
    title: 'Ndihma',
    path: '/support',
    icon: <IoIcons.IoMdHelpCircle className="iconn"/>,
    cName: 'nav-text'
  },
 
  
];