import React from "react";
import { BoldLink, BoxContainer, FormContainer, Input, MutedLink, Button } from "./sharedToForms";
import { Marginer } from "../marginer"
import { useContext } from "react";
import { AccountContext } from "./accountContext";
import { useState } from "react";
import { useNavigate } from "react-router";


export default function SignUpForm(props) {
    const { switchToSignin } = useContext(AccountContext);
    const [username, setUsername] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');

    const submitSignUpForm = async e => {
        e.preventDefault();
      try {
        const body = { username, email, password, confirmPassword };
        const response = fetch("http://localhost:5000/api/Users", {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(body)
        })
        console.log(response);

      } catch (err) {
        console.error(err.message);
      }
    }

    let navigate = useNavigate();
    function goToSignIn() {
      navigate("/signin")
    }

  return(
    <BoxContainer>
      <FormContainer onSubmit={submitSignUpForm}>
        <Marginer direction="vertical" margin="3em"></Marginer>
        <Input type="username" placeholder="Username" value={username} onChange={e => setUsername(e.target.value)}/>
        <Input type="email" placeholder="Email" value={email} onChange={e => setEmail(e.target.value)}/>
        <Input type="password" placeholder="Password" value={password} onChange={e => setPassword(e.target.value)}/>
        <Input type="password" placeholder="Confirm Password" value={confirmPassword} onChange={e => setConfirmPassword(e.target.value)}/>
        

      </FormContainer>
      <Marginer direction="vertical" margin={10} />
        
        <Marginer direction="vertical" margin="1em" />
        <Button type="submit" href="#" onClick={goToSignIn}>Sign up.</Button>
        <Marginer direction="vertical" margin=".5em"></Marginer>;
        <MutedLink href="#">Have an account? <BoldLink href="" onClick={goToSignIn}>Sign in</BoldLink></MutedLink>
    </BoxContainer>
  )
}
