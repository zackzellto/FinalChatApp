import React from "react";
import { FormContainer, Input, MutedLink, Button } from "./sharedToForms";
import { Marginer } from "../marginer";
import { useState } from "react";
import { Link, Navigate } from "react-router-dom";
import {
  HeaderContainer,
  InnerContainer,
  HeaderText,
  BackDrop,
  TopContainer,
  BoxContainer,
} from "../loginpage/index";


export function SignUpForm(props) {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [redirect, setRedirect] = useState(false);

  const submitSignUpForm = async (e) => {
    e.preventDefault();
    
      
      await fetch('https://localhost:7089/api/register', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          Username: username,
          Password: password
        }),
      })};

  if(redirect){
    return <Navigate to="/login" />
  }
  

  return (
    <BoxContainer id="signup-container">
      <TopContainer>
        <BackDrop id="signup-backdrop" />
        <HeaderContainer>
          <HeaderText id="signin-header">ChatApp</HeaderText>
        </HeaderContainer>
        <InnerContainer>
          
          <FormContainer  >
            <Marginer direction="vertical" margin="3em"></Marginer>
            <div id="signup-input-group" >
              <Input
                type="username"
                required
                placeholder="Username"
                value={username}
                onChange={e => setUsername(e.target.value)}
              />
              <Input
                type="password"
                required
                placeholder="Password"
                value={password}
                onChange={e => setPassword(e.target.value)}
              />
            </div>
          <Marginer direction="vertical" margin={10} />
          <Marginer direction="vertical" margin="1em" />
            <Button id="signup-btn" type="submit" onClick={submitSignUpForm}>
              Sign up.
            </Button>
          <Marginer direction="vertical" margin=".5em"></Marginer>;
          <MutedLink id="signup-link" href="#">
            Have an account? <Link style={{ fontWeight: "700", color: "black" }} to="/login">Sign in</Link>
          </MutedLink>
          </FormContainer>
        </InnerContainer>
      </TopContainer>
    </BoxContainer>
  );
}
