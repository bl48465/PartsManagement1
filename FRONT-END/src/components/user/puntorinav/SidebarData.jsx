import React from 'react';
import * as FaIcons from 'react-icons/fa';
import * as AiIcons from 'react-icons/ai';
import * as IoIcons from 'react-icons/io';
import * as RiIcons from 'react-icons/ri';

export const SidebarData = [
  {
    title: 'Shtëpia',
    path: '/HomeUser',
    icon: <AiIcons.AiFillHome className="iconn" />,
    cName: 'nav-text'
  },
  {
    title: 'Users',
    path: '/Users',
    icon: <IoIcons.IoMdHelpCircle className="iconn"/>,
    cName: 'nav-text'
  },
  {
    title: 'Kërkesa',
    path: '/Kerkesa',
    icon: <IoIcons.IoMdHelpCircle className="iconn"/>,
    cName: 'nav-text'
  },
  
];