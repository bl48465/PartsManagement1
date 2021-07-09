import React, {useState} from 'react';
import validate from './validateInfo';
import useForm from './useForm';
import './Form.css';
import axios from 'axios';



const FormSignup = ({ submitForm }) => {
  
  const { handleChange, handleSubmit, values, errors } = useForm(
    submitForm,
    validate
  );
  //Provo provo se e gjan
    const emriMbiemri=values.emrimbiemri;
    const email=values.email;
    const marka=values.marka;
    const modeli=values.modeli;
    const mbishkrimi=values.mbishkrimi;

    // console.log(emriMbiemri);

    
    
  const ShtoKerkesa=async () =>{
         
    
    axios.post("http://localhost:5000/api/Kerkesa",{emriMbiemri,email,marka,modeli,mbishkrimi},{withCredentials:false})
    .then((response)=>{
        console.log(response.data.message)
    })
    .catch((error)=>{
        console.log(error.data);
    })
}

  return (
    <div className='form-content-right'>
      <form onSubmit={handleSubmit} className='form' noValidate>
        <h1>
          Nese ka munges te ndonje Modeli ose Marke ketu mund te beni kerkes per ta shtuar.<br></br>
          Rrezbekte
        </h1>
        <div className='form-inputs'>
          <label className='form-label'>Emri Mbiemri</label>
          <input
            className='form-input'
            type='text'
            name='emrimbiemri'
            placeholder='Emri dhe Mbiemri'
            value={values.emrimbiemri}
            onChange={handleChange}
          />

          {errors.emrimbiemri && <p>{errors.emrimbiemri}</p>}
        </div>
        <div className='form-inputs'>
          <label className='form-label'>Email</label>
          <input
            className='form-input'
            type='email'
            name='email'
            placeholder='Enter your email'
            value={values.email}
            onChange={handleChange}
          />
          {errors.email && <p>{errors.email}</p>}
        </div>
        <div className='form-inputs'>
          <label className='form-label'>Marka</label>
          <input
            className='form-input'
            type='text'
            name='marka'
            placeholder='Shenoni Marken'
            value={values.marka}
            onChange={handleChange}
          />
          {errors.marka && <p>{errors.marka}</p>}
        </div>
        <div className='form-inputs'>
          <label className='form-label'>Modeli</label>
          <input
            className='form-input'
            type='text'
            name='modeli'
            placeholder='Shenoni Modelin'
            value={values.modeli}
            onChange={handleChange}
          />
          {errors.modeli && <p>{errors.modeli}</p>}
        </div>
        <div className='form-inputs'>
          <label className='form-label'>Mbishkrimi</label>
          <input
            className='form-input'
            type='text'
            name='mbishkrimi'
            placeholder='Shenoni ndonje mbishkrim'
            value={values.mbishkrimi}
            onChange={handleChange}
          />
          {errors.mbishkrimi && <p>{errors.mbishkrimi}</p>}
        </div>
        
        <button className='form-input-btn' type='submit' onClick={ShtoKerkesa}>
          Beni kerkesen
        </button>
        
      </form>
    </div>
  );
};

export default FormSignup;
