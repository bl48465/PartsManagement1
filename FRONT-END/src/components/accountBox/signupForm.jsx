import axios from 'axios'
import React, { useContext, useState } from "react";
import {
  BoldLink,
  BoxContainer,
  FormContainer,
  Input,
  MutedLink,
  SubmitButton,
  ErrMessage
} from "./common";
import { Marginer } from "../marginer";
import { AccountContext } from "./accountContext";
import { useForm } from "react-hook-form";

export function SignupForm() {


  const { switchToSignin } = useContext(AccountContext);
  const url = "http://localhost:44395/api/user/register";
  const [data, setData] = useState({
    Emri: '',
    Mbiemri: '',
    Company: '',
    Email: '',
    Password: '',
    ConfirmPassword: '',
    formErrors: {
      ErrEmri: '',
      ErrMbiemri: '',
      ErrCompany: '',
      ErrEmail: '',
      ErrPassword: '',
      ErrConfirmPassword: '',
      ErrAll:'Rishikoni të dhënat',
      ErrExists:'Emaili eshte ne perdorim'
    }
  })

  function submit(e) {

    e.preventDefault();

    axios.post(url, {
      Emri: data.Emri,
      Mbiemri: data.Mbiemri,
      Company: data.Company,
      Email: data.Email,
      Password: data.Password,
      ConfirmPassword: data.ConfirmPassword
    })
      .catch(err => {
        if(err.response.status === 500){
          data.formErrors.ErrExists = '';
        }
      })
    }



  function handleEmri(e) {
    const newdata = { ...data }
    newdata[e.target.name] = e.target.value

    if (newdata.Emri.length < 3 || newdata.Emri === '') {
      newdata.formErrors.ErrEmri = 'Ju lutem shtypni një emër valid';
    }
    else {
      newdata.formErrors.ErrEmri = '';

    }
    setData(newdata)

  }

  function handleMbiemri(e) {
    const newdata = { ...data }
    newdata[e.target.name] = e.target.value

    if (newdata.Mbiemri.length < 3 || newdata.Mbiemri === '') {
      newdata.formErrors.ErrMbiemri = 'Ju lutem shtypni një mbiemër valid';

    }
    else {
      newdata.formErrors.ErrMbiemri = '';

    }
    setData(newdata)

  }

  function handleCompany(e) {

    const newdata = { ...data }
    newdata[e.target.name] = e.target.value

    if (newdata.Company.length < 3 || newdata.Company === '') {
      newdata.formErrors.ErrCompany = 'Ju lutem shtypni një kompani valide';

    }
    else {
      newdata.formErrors.ErrCompany = '';
    }

    setData(newdata)


  }

  function handleEmail(e) {

    const emailRegex = /\S+@\S+\.\S+/;
    const newdata = { ...data }
    newdata[e.target.name] = e.target.value

    if (newdata.Email.length < 3 || newdata.Email === '' || !newdata.Email.match(emailRegex)) {
      newdata.formErrors.ErrEmail = 'Ju lutem shtypni një email valid';

    }
    else {
      newdata.formErrors.ErrEmail = '';

    }

    setData(newdata)


  }

  function handlePassword(e) {

    const newdata = { ...data }
    newdata[e.target.name] = e.target.value

    if (newdata.Password.length < 8 || newdata.Password === '') {
      newdata.formErrors.ErrPassword = 'Ju lutem shtypni një fjalëkalim valid';
    }
    else {
      newdata.formErrors.ErrPassword = '';

    }

    setData(newdata)


  }

  function handleConfirmPassword(e) {

    const newdata = { ...data }
    newdata[e.target.name] = e.target.value

    if (newdata.ConfirmPassword.length < 8 || newdata.ConfirmPassword !== newdata.Password) {
      newdata.formErrors.ErrConfirmPassword = 'Fjalëkalimet nuk përputhen';
    }
    else {
      newdata.formErrors.ErrConfirmPassword = '';
    }

    setData(newdata)

  }

  return (
    <BoxContainer>
      
      <ErrMessage>{data.formErrors.ErrAll}</ErrMessage>
      <ErrMessage>{data.formErrors.ErrExists}</ErrMessage>
      <FormContainer>
        <ErrMessage>{data.formErrors.ErrEmri}</ErrMessage>
        <Input onChange={(e) => handleEmri(e)} type="text" placeholder="Emri" name="Emri" value={data.Emri} />

        <ErrMessage>{data.formErrors.ErrMbiemri}</ErrMessage>
        <Input onChange={(e) => handleMbiemri(e)} type="text" placeholder="Mbiemri" name="Mbiemri" value={data.Mbiemri} />

        <ErrMessage>{data.formErrors.ErrCompany}</ErrMessage>
        <Input onChange={(e) => handleCompany(e)} type="text" placeholder="Kompania" name="Company" value={data.Company} />

        <ErrMessage>{data.formErrors.ErrEmail}</ErrMessage>
        <Input onChange={(e) => handleEmail(e)} type="email" placeholder="Emaili" name="Email" value={data.Email} />

        <ErrMessage>{data.formErrors.ErrPassword}</ErrMessage>
        <Input onChange={(e) => handlePassword(e)} type="password" placeholder="Fjalëkalimi" name="Password" value={data.Password} />

        <ErrMessage>{data.formErrors.ErrConfirmPassword}</ErrMessage>
        <Input onChange={(e) => handleConfirmPassword(e)} type="password" placeholder="Konfirmo" name="ConfirmPassword" value={data.ConfirmPassword} />

      </FormContainer>
      <Marginer direction="vertical" margin={10}/>
      
      <SubmitButton type="submit" onClick={(e) => submit(e)}>Regjistrohu</SubmitButton>
      <Marginer direction="vertical" margin="1em"/>
      <MutedLink href="#">
        Jeni regjistruar më parë?
          <BoldLink href="#" onClick={switchToSignin}>
          Kyquni
          </BoldLink>
      </MutedLink>
    </BoxContainer>
  );
}

