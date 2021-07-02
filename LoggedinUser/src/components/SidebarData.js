import React from 'react';
import * as FaIcons from 'react-icons/fa';
import * as AiIcons from 'react-icons/ai';
import * as IoIcons from 'react-icons/io';

export const SidebarData = [
  {
    title: 'Home',
    path: '/',
    icon: <AiIcons.AiFillHome className="iconn" />,
    cName: 'nav-text'
  },
  {
    title: 'Komentet',
    path: '/komente',
    icon: <IoIcons.IoIosPaper className="iconn"/>,
    cName: 'nav-text'
  },
  {
    title: 'Porosite',
    path: '/Porosite',
    icon: <FaIcons.FaUser className="iconn" />,
    cName: 'nav-text'
  },
  {
    title: 'Furnitoret',
    path: '/furnitori',
    icon: <IoIcons.IoMdPeople className="iconn"/>,
    cName: 'nav-text'
  },
  {
    title: 'Sektoret',
    path: '/Sektoret',
    icon: <FaIcons.FaEnvelopeOpenText className="iconn"/>,
    cName: 'nav-text'
  },
  {
    title: 'Support',
    path: '/support',
    icon: <IoIcons.IoMdHelpCircle className="iconn"/>,
    cName: 'nav-text'
  },
  {
    title: 'Kerkese',
    path: '/Kerkesa',
    icon: <IoIcons.IoMdHelpCircle className="iconn"/>,
    cName: 'nav-text'
  }
];