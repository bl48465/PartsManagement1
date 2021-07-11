import React from 'react';
import * as FaIcons from 'react-icons/fa';
import * as AiIcons from 'react-icons/ai';
import * as IoIcons from 'react-icons/io';

export const SidebarData = [
  {
    title: 'Shtëpia',
    path: '/HomeAdmin',
    icon: <AiIcons.AiFillHome className="iconn" />,
    cName: 'nav-text'
  },
  {
    title: 'Përdoruesit',
    path: '/UsersAdmin',
    icon: <FaIcons.FaUser className="iconn"/>,
    cName: 'nav-text'
  },
  

  {
    title: 'Mesazhet',
    path: '/MessagesAdmin',
    icon: <FaIcons.FaEnvelopeOpenText className="iconn"/>,
    cName: 'nav-text'
  },

  {
    title: 'Ndihma',
    path: '/SupportAdmin',
    icon: <IoIcons.IoMdHelpCircle className="iconn"/>,
    cName: 'nav-text'
  },
 
  
];