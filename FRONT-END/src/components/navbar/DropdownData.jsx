import React from 'react';
import * as FaIcons from 'react-icons/fa';
import * as AiIcons from 'react-icons/ai';
import * as IoIcons from 'react-icons/io';

export const DropdownData = [
  {
    title: 'Settings',
    path: '/settings',
    icon: <AiIcons.AiFillHome />,
    cName: 'nav-text'
  },
  {
    title: 'Logout',
    path: '/',
    icon: <IoIcons.IoIosPaper />,
    cName: 'nav-text'
  }
];