import React from "react";
import { BoldLink, BoxContainer, FormContainer, Input, MutedLink, Button } from "./sharedToForms";
import { Marginer } from "../marginer"
import { AccountContext } from "./accountContext";
import { useContext } from "react"




 function LoginForm(props) {
  const { switchToSignup } = useContext(AccountContext)
  const { switchToApp } = useContext(AccountContext)
 
  

  return(
    <BoxContainer>
      <FormContainer>
        <Marginer direction="vertical" margin="4em"></Marginer>
        <Input type="username" placeholder="Username" />
        <Input type="password" placeholder="Password" />
        

      </FormContainer>
      <Marginer direction="vertical" margin={10} />
        
        <Marginer direction="vertical" margin="1em" />
      
        <Button type="btn" onClick={switchToApp}>Sign in.</Button>
        <Marginer direction="vertical" margin=".5em"></Marginer>;
        <MutedLink href="#">Don't have an account? <BoldLink href="#" onClick={switchToSignup}>Sign up</BoldLink></MutedLink>
    </BoxContainer>
  )
}

export default LoginForm