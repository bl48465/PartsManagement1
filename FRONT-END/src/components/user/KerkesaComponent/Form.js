import React, { useState } from 'react';
import './Form.css';
import FormSignup from './FormSignup';
import FormSuccess from './FormSuccess';
import Navbar from '../navbar/Navbar';
import bmw from './img/Capture.PNG'

const Form = () => {
  const [isSubmitted, setIsSubmitted] = useState(false);

  function submitForm() {
    setIsSubmitted(true);
  }
  return (
    <>
    <Navbar/>
      <div className='form-container'>
        
        <div className='form-content-left'>
          <img className='form-img' src={bmw} alt='Me BMW mer bab' />
        </div>
        {!isSubmitted ? (
          <FormSignup submitForm={submitForm} />
        ) : (
          <FormSuccess />
        )}
      </div>
    </>
  );
};

export default Form;
