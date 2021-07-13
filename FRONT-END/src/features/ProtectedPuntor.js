import React from 'react'
import { Route, Redirect } from 'react-router-dom';

export const ProtectedPuntor = ({ isAuth:isAuth, role:role, component: Component, ...rest }) => {
    return (
        <Route {...rest} render={(props) => {
            
            if (isAuth===true && role==='Puntor') {
                return <Component />
            }
            else {
                return (
                    <Redirect to={{ pathname: '/NotFound', state: { from: props.location } }} />
                );
            }
        }}
        />
    );
}