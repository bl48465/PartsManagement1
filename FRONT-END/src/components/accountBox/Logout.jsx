import React from 'react'
import { useHistory } from 'react-router';
import { AccountBox } from '.';
import { useDispatch } from 'react-redux';
import { logout } from '../../reducers/rootReducer';
import { log } from '../../reducers/logReducer';

export const Logout = () => {
 const dispatch = useDispatch();
let history = useHistory();
dispatch(logout());
dispatch(log({logStatus:false}));
        window.localStorage.removeItem('token');
        window.localStorage.removeItem('userId');
        window.localStorage.removeItem('emri');
        window.localStorage.removeItem('roli');
        history.push('/');
        return(
           <AccountBox/>
        )
}
