import React from 'react';
import * as MdIcons from 'react-icons/md';
import * as RiIcons from 'react-icons/ri';
import * as IoIcons from 'react-icons/io';

export const DropdownData = [
  {
    title: 'Cilësimet',
    path: '/settings',
    icon: <MdIcons.MdSettings className="iconn" />,
    cName: 'nav-text'
  },
  {
    title: 'Çkyçu',
    path: '/',
    icon: <RiIcons.RiLogoutBoxRFill className="iconn"/>,
    cName: 'nav-text'
  }
];