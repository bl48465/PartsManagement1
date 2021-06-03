import axios from 'axios'
import React, {useContext, useState} from "react";
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

export function SignupForm(){

    const [formState, setFormState] = useState({
      formValues: {
        Emri: '',
        Mbiemri: '',
        Company: '',
        Email: '',
        Password: '',
        ConfirmPassword: '',
      },
      formErrors: {
        Emri: '',
        Mbiemri: '',
        Company: '',
        Email: '',
        Password: '',
        ConfirmPassword: '',
      },
      formValidity: {
        Emri: false,
        Mbiemri: false,
        Company: false,
        Email: false,
        Password: false,
        ConfirmPassword: false
      }
    });

    const handleValidation = target => {

      const { name, value } = target;
      const fieldValidationErrors = formState.formErrors;
      const validity = formState.formValidity;

      const isEmail = name === "Email";
      const isPassword = name === "Password";
      const isConfirmPassword = name === "ConfirmPassword";
      const emailTest = /^[^\s@]+@[^\s@]+\.[^\s@]{2,}$/i;
      const PasswordReg = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$/;
  
      validity[name] = value.length > 3 ;
      fieldValidationErrors[name] = validity[name]
        ? ""
        : `${name} duhet të ketë së paku 3 shkronja `;
      if (validity[name]) {
        if (isEmail) {
          validity[name] = emailTest.test(value);
          fieldValidationErrors[name] = validity[name]
            ? ""
            : `${name} duhet të jetë valid`;
        }
        if (isPassword) {
          validity[name] = PasswordReg.test(value);
          fieldValidationErrors[name] = validity[name]
            ? ""
            : `Fjalëkalimi duhet të përmbajë së paku 8 shkronja (1 numër, 1 shkronjë të madhe)`;
        }
        if (isConfirmPassword) {
          validity[name] = formState.formValues.ConfirmPassword === formState.formValues.Password
          fieldValidationErrors[name] = validity[name]
            ? ""
            : `Fjalëkalimet nuk përputhen`;
        }
      }

  setFormState({
        ...formState,
        formErrors: fieldValidationErrors,
        formValidity: validity
      });
    };

    const handleChange = ({ target }) => {
      const { formValues } = formState;
      formValues[target.name] = target.value;
      setFormState({ formValues });
      handleValidation(target);
    };

    const handleSubmit = event => {
      event.preventDefault();
      const { formValues, formValidity } = formState;
      if (Object.values(formValidity).every(Boolean)) {
        axios.post("http://localhost:44395/api/user/register",formValues);
        console.log(formValues);
      } else {
        for (let key in formValues) {
          let target = {
            name: key,
            value: formValues[key]
          };
          handleValidation(target);
        }
      }
    };

    const { switchToSignin } = useContext(AccountContext);

  return (
    <BoxContainer>
      <FormContainer onSubmit={handleSubmit}>
        <ErrMessage>{formState.formErrors.Emri}</ErrMessage>
        <Input  type="text" placeholder="Emri" name="Emri" onChange={handleChange}  value={formState.formValues.Emri} />
        <ErrMessage>{formState.formErrors.Mbiemri}</ErrMessage>
        <Input  type="text" placeholder="Mbiemri" name="Mbiemri" onChange={handleChange} value={formState.formValues.Mbiemri} />
        <ErrMessage>{formState.formErrors.Company}</ErrMessage>
        <Input  type="text" placeholder="Kompania" name="Company" onChange={handleChange} value={formState.formValues.Company} />
        <ErrMessage>{formState.formErrors.Email}</ErrMessage>
        <Input  type="email" placeholder="Emaili" name="Email" onChange={handleChange} value={formState.formValues.Email}/>
        <ErrMessage>{formState.formErrors.Password}</ErrMessage>
        <Input  type="password" placeholder="Fjalëkalimi" name="Password" onChange={handleChange} value={formState.formValues.Password}/>
        <ErrMessage>{formState.formErrors.ConfirmPassword}</ErrMessage>
        <Input  type="password" placeholder="Fjalëkalimi" name="ConfirmPassword" onChange={handleChange} value={formState.formValues.ConfirmPassword}/>
      </FormContainer>
      <Marginer direction="vertical" margin={10} />
      <SubmitButton type="submit" onClick={handleSubmit} >Regjistrohu</SubmitButton>
      <Marginer direction="vertical" margin="1em" />
      <MutedLink href="#">
        Jeni regjistruar më parë?
          <BoldLink href="#" onClick={switchToSignin}>
          Kyquni
          </BoldLink>
      </MutedLink>
    </BoxContainer>
  );
}

