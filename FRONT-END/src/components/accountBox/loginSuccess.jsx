import React, { useState, useEffect,useCookies } from "react";
import axios from 'axios';
import {SubmitButton} from './common';
import {Cookies} from 'react-cookie';

export const Home = () =>{
  const cookie = new Cookies();
 
  const [userInfo, setuserInfo] = useState({
    userValues: {
      userID:'',
      emri:'',
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
                  email:response.data.email, 
                  password:response.data.password,
                  kompania:response.data.kompania})
    })

  },[])

  const logOutSession = async() => {
  
  
   cookie.set('jwt',1,{maxAge:1});
  
  
    axios.post("http://localhost:5000/api/Auth/logout",{ withCredentials: true })
    .then((response)=>{
    console.log(response.data.message)
    })
    .catch((error)=>{
      console.log(error.data);
    })
      
  }

return(

      <div>
        <h1>Welcome {userInfo.emri}</h1>
        <h3>Your ID: {userInfo.userID}</h3>
        <h3>Your email: {userInfo.email}</h3>
        <h3>Your password: {userInfo.password}</h3>
        <h3>Your Company: {userInfo.kompania}</h3>

        
        <SubmitButton type="submit" onClick={logOutSession}>Log out</SubmitButton>

      </div>


 
);
};
export default Home;