import React from 'react';
import * as FaIcons from 'react-icons/fa';
import * as AiIcons from 'react-icons/ai';
import * as IoIcons from 'react-icons/io';
import * as RiIcons from 'react-icons/ri';

export const SidebarData = [
  {
    title: 'Shtëpia',
    path: '/',
    icon: <AiIcons.AiFillHome className="iconn" />,
    cName: 'nav-text'
  },
  {
    title: 'Komentet',
    path: '/Komente',
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
    title: 'Produktet',
    path: '/Produktet',
    icon: <AiIcons.AiOutlineDropbox className="iconn"/>,
    cName: 'nav-text'
  },
  
  {
    title: 'Shitjet',
    path: '/Shitjet',
    icon: <RiIcons.RiMoneyEuroCircleFill className="iconn"/>,
    cName: 'nav-text'
  },

  {
    title: 'Ndihma',
    path: '/Support',
    icon: <IoIcons.IoMdHelpCircle className="iconn"/>,
    cName: 'nav-text'
  },
  {
    title: 'Kërkesa',
    path: '/Kerkesa',
    icon: <IoIcons.IoMdHelpCircle className="iconn"/>,
    cName: 'nav-text'
  }
];