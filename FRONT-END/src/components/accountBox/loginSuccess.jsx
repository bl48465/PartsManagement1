import React, { useState, useEffect } from "react";
import axios from 'axios';


export const Home = () =>{

  const token = window.localStorage.getItem('token');

  const config = {
    headers: {
      Authorization: 'Bearer ' + token}
  };

  useEffect (() => {

  if(token != null){
  axios.get('http://localhost:5000/api/User/current/'+ window.localStorage.getItem('userId'),config)
  .then((response)=>{
    console.log(response.data[0].emri);
  })
  }
  else{
    return {}
  }
  },[])

  const logout = async () => {
    window.localStorage.removeItem('token');
    window.localStorage.removeItem('userId');
  }

return(

      <div>
        <h3>Emri sektori : </h3>
        <button onClick={logout}>LOGOUT</button>
      </div>

);
};
export default Home;