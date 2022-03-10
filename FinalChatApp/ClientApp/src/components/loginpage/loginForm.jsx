import React from "react";
import { BoldLink, BoxContainer, FormContainer, Input, MutedLink, SubmitButton } from "./sharedToForms";
import { Marginer } from "../marginer"
import { AccountContext } from "./accountContext";
import { useContext } from "react";




export function LoginForm(props) {
  const { switchToSignup } = useContext(AccountContext)



  return(
    <BoxContainer>
      <FormContainer>
        <Marginer direction="vertical" margin="4em"></Marginer>
        <Input type="email" placeholder="Email" />
        <Input type="password" placeholder="Password" />
        

      </FormContainer>
      <Marginer direction="vertical" margin={10} />
        <MutedLink href="#">Forgot Password?[NOT FUNCTIONAL]</MutedLink>
        <Marginer direction="vertical" margin="1em" />
        <SubmitButton type="submit" href="#">Sign in.</SubmitButton>
        <Marginer direction="vertical" margin=".5em"></Marginer>;
        <MutedLink href="#">Don't have an account? <BoldLink href="#" onClick={switchToSignup}>Sign up</BoldLink></MutedLink>
    </BoxContainer>
  )
}
