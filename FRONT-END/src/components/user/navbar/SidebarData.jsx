import React from 'react';
import * as FaIcons from 'react-icons/fa';
import * as AiIcons from 'react-icons/ai';
import * as IoIcons from 'react-icons/io';
import * as RiIcons from 'react-icons/ri';

export const SidebarData = [
  {
    title: 'Shtëpia',
    path: '/UserPanel',
    icon: <AiIcons.AiFillHome className="iconn" />,
    cName: 'nav-text'
  },
  {
    title: 'Punëtorët',
    path: '/Punetoret',
    icon: <FaIcons.FaUser className="iconn"/>,
    cName: 'nav-text'
  },
  {
    title: 'Komentet',
    path: '/Komenti',
    icon: <IoIcons.IoIosPaper className="iconn"/>,
    cName: 'nav-text'
  },
  {
    title: 'Porositë',
    path: '/Porosite',
    icon: <FaIcons.FaShoppingBasket className="iconn" />,
    cName: 'nav-text'
  },
  {
    title: 'Furnitorët',
    path: '/Furnitori',
    icon: <FaIcons.FaShuttleVan className="iconn"/>,
    cName: 'nav-text'
  },
  {
    title: 'Sektorët',
    path: '/Sektori',
    icon: <AiIcons.AiFillDatabase className="iconn"/>,
    cName: 'nav-text'
  },
  {
    title: 'Produktet',
    path: '/Produkti',
    icon: <AiIcons.AiOutlineDropbox className="iconn"/>,
    cName: 'nav-text'
  },
  
  {
    title: 'Shto Shitje',
    path: '/Shitjet',
    icon: <RiIcons.RiMoneyEuroCircleFill className="iconn"/>,
    cName: 'nav-text'
  },

  {
    title: 'Ndihma',
    path: '/Ndihma',
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