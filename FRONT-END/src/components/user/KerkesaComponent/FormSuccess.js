import React from 'react';
import './Form.css';
import img from './img/img3.svg';

const FormSuccess = () => {
  return (
    <div className='form-content-right'>
      <h1 className='form-success'>E kemi marr kerkesen tuaj me sukses!</h1>
      <img className='form-img-2' src={img}/>
    </div>
  );
};

export default FormSuccess;
