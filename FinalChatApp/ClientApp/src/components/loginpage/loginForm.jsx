import React from "react";
import { BoxContainer, FormContainer, Input, MutedLink, Button } from "./sharedToForms";
import { Marginer } from "../marginer"
import {  Link } from "react-router-dom";

 function LoginForm(props) {
  
  return(
    <BoxContainer>
      <FormContainer>
        <Marginer direction="vertical" margin="4em"></Marginer>
        <Input type="username" placeholder="Username" />
        <Input type="password" placeholder="Password" />
      </FormContainer>
      <Marginer direction="vertical" margin={10} />
        <Marginer direction="vertical" margin="1em" />
        <Link to="/chat"><Button style={{width: "400px"}} type="btn">Sign in.</Button></Link>
        <Marginer direction="vertical" margin=".5em"></Marginer>
        <MutedLink href="#">Don't have an account? <Link style={{ fontWeight: "700", color: "black"}} href="" to="/signup">Sign up</Link></MutedLink>
    </BoxContainer>
  )
}

export default LoginForm