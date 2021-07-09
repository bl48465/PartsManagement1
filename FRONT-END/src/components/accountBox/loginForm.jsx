import React, { useContext, useState, useEffect } from "react";
import {Redirect} from 'react-router-dom';
import { useDispatch } from "react-redux";
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
import axios from "axios";
import { login } from "../../reducers/rootReducer";
import {log} from "../../reducers/logReducer";

export function LoginForm(props) {
  const [redirect, setRedirect] = useState(false);
  const [error, setError] = useState(true);
  const[fail,setFail]= useState({message:''});
  const dispatch = useDispatch();
  
  const [form, setForm] = useState({
    formValues: {
      email: '',
      password: ''
    }
  });

  const handleChange = ({ target }) => {
    const { formValues } = form;
    formValues[target.name] = target.value;
    setForm({ formValues });
  };

  const initialSession = async () => {
    
    const { formValues } = form;
    await axios.post("http://localhost:5000/api/Account/login",formValues)
    .then((response) =>{
      if(response.data){
        window.localStorage.setItem('token',response.data.token);
        window.localStorage.setItem('userId',response.data.userId);
        window.localStorage.setItem('emri',response.data.emri);
        window.localStorage.setItem('roli',response.data.roli);
        
    
        dispatch(login({
        userId:response.data.userId,
        email:formValues.email,
        emri:response.data.emri,
        roli:response.data.roli,
        token:response.data.token,
        loggedIn:true
        }));

        dispatch(log({logStatus:true}));


        setRedirect(true);
      }
    })
      .catch((error) => {
        console.log(formValues);
        setError(true);
        setFail({message:"Të dhënat gabim!"});
        setRedirect(false)
        console.log(error);
      })
  }

  const { switchToSignup } = useContext(AccountContext);

  if(redirect===true){
    return <Redirect to="/Dashboard"/>;}

  return (
    <BoxContainer>
      <FormContainer>
        <ErrMessage>{fail.message}</ErrMessage>
        <Input type="email" placeholder="Emaili" name="email" onChange={handleChange} />
        <Input type="password" name="password" placeholder="Fjalëkalimi" onChange={handleChange} />
      </FormContainer>
      <Marginer direction="vertical" margin={10} />
      <MutedLink href="#">Keni harruar fjalëkalimin?</MutedLink>
      <Marginer direction="vertical" margin="1.6em" />
      <SubmitButton type="submit" onClick={() => initialSession()}>Kyquni</SubmitButton>
      <Marginer direction="vertical" margin="1em" />
      <MutedLink href="#">
        Nuk keni ende llogari?{" "}
        <BoldLink href="#" onClick={switchToSignup}>
          Regjistrohu
        </BoldLink>
      </MutedLink>
    </BoxContainer>
  );
}
