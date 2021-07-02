import React, { useState, useEffect,useCookies } from "react";
import axios from 'axios';
import {SubmitButton} from './common';
import {Cookies} from 'react-cookie';
import { Navbari } from "../navbar/Navbar";


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
  
    await axios.post("http://localhost:5000/api/Auth/logout",{ withCredentials: true })
    .then((response)=>{
    console.log(response.data.message)
    })
    .catch((error)=>{
      console.log(error.data);
    })
      
  }

return(

  <Navbari data={userInfo}/>
);
};
export default Home;