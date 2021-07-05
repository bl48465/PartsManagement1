import React from 'react';
import './userindex.css';
import styled from "styled-components";
import Navbar from './navbar/Navbar';
import {BrowserRouter,Switch,Route} from 'react-router-dom';


import { SektoriTable } from './Sektori'
import { KomentiTable } from './Komenti';

const AppContainer = styled.div`
    width: 100%;
    height: 100%;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
`;
function UserApp() {
    return (
        <BrowserRouter>
    
    </BrowserRouter>
    );
}

export default UserApp;