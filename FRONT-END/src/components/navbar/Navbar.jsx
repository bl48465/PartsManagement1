import React, { useState, useEffect,useCookies } from "react";
import axios from 'axios';
import * as FaIcons from 'react-icons/fa';
import * as AiIcons from 'react-icons/ai';
import * as RiIcons from 'react-icons/ri';
import { Link } from 'react-router-dom';
import { SidebarData } from './SidebarData';
import './Navbar.css';
import { IconContext } from 'react-icons';
import { DropdownData } from './DropdownData';
import styled from "styled-components";

const MotivationalText = styled.h1`
  font-size: 20px;
  font-weight: 500;
  text-decoration:none;
  color: #fff;
  margin: 0;
  text-align: center;
`;

export function Navbari(props) {

  const [userInfo, setuserInfo] = useState({
    userValues: {
      userID:'',
      emri:'',
      mbiemri:'',
      email: '',
      password: '',
      kompania:''

    }
  });

  useEffect(() => {
    axios.get("http://localhost:5000/api/Auth/user",{ withCredentials: true })
    .then((response) => {
      console.log();
      setuserInfo({userID:response.data.userID,
                  emri:response.data.emri, 
                  mbiemri:response.data.mbiemri, 
                  email:response.data.email, 
                  password:response.data.password,
                  kompania:response.data.kompania})
    })

  },[])

  const [sidebar, setSidebar] = useState(false);
  const showSidebar = () => setSidebar(!sidebar);

  const[open, setOpen] = useState(false);
  const showDropdown =() => setOpen(!open);

  return (
    <>
      <IconContext.Provider value={{ color: 'FC4747' }}>
        <div className='navbar'>
            <Link to='#' className='menu-bars'>
              <FaIcons.FaBars onClick={showSidebar} />
            </Link>
              
            <Link to='#' className='menu-user' onClick={showDropdown}>
                  <RiIcons.RiUserFill/>
                  <MotivationalText className="user-name">{userInfo.emri}  {userInfo.mbiemri}</MotivationalText>
           </Link>
      
        </div>

        <nav className={open ? 'dropdown active' : 'dropdown'}>
          <ul className='nav-menu-items' onClick={showDropdown}>
            <li className='dropdown-toggle'>
              <Link to='#' className='menu-user'>
                <AiIcons.AiOutlineClose />
              </Link>
            </li>
            {DropdownData.map((item, index) => {
              return (
                <li key={index} className={item.cName}>
                  <Link to={item.path}>
                    {item.icon}
                    <span>{item.title}</span>
                  </Link>
                </li>
              );
            })}
          </ul>
        </nav>

        <nav className={sidebar ? 'nav-menu active' : 'nav-menu'}>
          <ul className='nav-menu-items' onClick={showSidebar}>
            <li className='dropdown-toggle'>
              <Link to='#' className='menu-bars'>
                <AiIcons.AiOutlineClose />
              </Link>
            </li>
            {SidebarData.map((item, index) => {
              return (
                <li key={index} className={item.cName}>
                  <Link to={item.path}>
                    {item.icon}
                    <span>{item.title}</span>
                  </Link>
                </li>
              );
            })}
          </ul>
        </nav>
      </IconContext.Provider>
    </>
  );
}

export default Navbari;