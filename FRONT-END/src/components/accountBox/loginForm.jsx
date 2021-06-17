import React, { useContext, useState } from "react";

import {
  BoldLink,
  BoxContainer,
  FormContainer,
  Input,
  MutedLink,
  SubmitButton,
} from "./common";
import { Marginer } from "../marginer";
import { AccountContext } from "./accountContext";
import axios from "axios";
import { useHistory } from 'react-router-dom';



export function LoginForm(props) {
  const history = useHistory()
  const [error, setError] = useState(true);
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


    axios.post("http://localhost:5000/api/Auth/login", formValues, { withCredentials: true })
      .then((response) => {     
      history.push("/");
      })
      .catch((error) => {
        setError(true);
      })
  }



  const { switchToSignup } = useContext(AccountContext);

  return (
    <BoxContainer>
      <FormContainer>
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
