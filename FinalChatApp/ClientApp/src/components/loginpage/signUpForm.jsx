import React from "react";
import { FormContainer, Input, MutedLink, Button } from "./sharedToForms";
import { Marginer } from "../marginer";
import { useState } from "react";
import { Link } from "react-router-dom";
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
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");

  const submitSignUpForm = async (e) => {
    e.preventDefault();
    try {
      const body = { username, email, password, confirmPassword };
      const response = fetch("http://localhost:5000/api/Users", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(body),
      });
      console.log(response);
    } catch (err) {
      console.error(err.message);
    }
  };

  return (
    <BoxContainer>
      <TopContainer>
        <BackDrop

        />
        <HeaderContainer>
          <HeaderText>ChatApp</HeaderText>
        </HeaderContainer>

        <InnerContainer>
          <FormContainer>
            <Marginer direction="vertical" margin="3em"></Marginer>
            <Input
              type="username"
              placeholder="Username"
              value={username}
              onChange={(e) => setUsername(e.target.value)}
            />
            <Input
              type="email"
              placeholder="Email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
            />
            <Input
              type="password"
              placeholder="Password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
            />
            <Input
              type="password"
              placeholder="Confirm Password"
              value={confirmPassword}
              onChange={(e) => setConfirmPassword(e.target.value)}
            />
          </FormContainer>
          <Marginer direction="vertical" margin={10} />
          <Marginer direction="vertical" margin="1em" />
          <Link to="/signin">
            <Button type="submit" href="#">
              Sign up.
            </Button>
          </Link>
          <Marginer direction="vertical" margin=".5em"></Marginer>;
          <MutedLink href="#">
            Have an account? <Link to="/signin">Sign in</Link>
          </MutedLink>
        </InnerContainer>
      </TopContainer>
    </BoxContainer>
  );
}
