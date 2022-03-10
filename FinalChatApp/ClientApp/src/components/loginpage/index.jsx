import React from "react";
import styled from "styled-components";
import { LoginForm } from "./loginForm";
import { motion } from "framer-motion";
import { useState } from "react";
import { AccountContext } from "./accountContext";
import { SignUpForm } from "./signUpForm";


const BoxContainer = styled.div`
filter: drop-shadow(16px 16px 10px black);
  width: 480px;
  min-height: 750px;
  display: flex;
  flex-direction: column;
  border-radius: 16px;
  background-color: #fff;
  box-shadow: 0 0 5px rgba(15, 15, 15, 0.28);
  position: relative;
  overflow: hidden;
`;

const TopContainer = styled.div`
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  padding: 0 1.8em;
  padding-bottom: 5em;
`;

const BackDrop = styled(motion.div)`
width: 150%;
height: 650px;  
position: absolute;
  display: flex;
  flex-direction: column;
  border-radius: 30%;
  transform: rotate(60deg);
  top: -350px;
  left: -160px;
  filter: drop-shadow(6px 6px 5px black);
background: linear-gradient(90deg, rgba(2,0,36,1) 0%, rgba(9,9,121,1) 35%, rgba(0,212,255,1) 100%);
z-index: 10;
`;

const HeaderContainer = styled.div`
  width: 100%;
  display: flex;
  flex-direction: column;
`;

const HeaderText = styled.h2`
font-family: 'Akaya Telivigala';
  font-size: 100px;
  font-weight: 600;
  line-height: 1.24;
  color: #fff;
  z-index: 10;
  margin: 0;
  margin-right: 3em;
  position: relative;
  top: 40px;
  filter: drop-shadow(6px 6px 5px black);
`;

const InnerContainer = styled.div`
  width: 100%;
  display: flex;
  flex-direction: column;
  padding: 1em;
`;

const backdropVariants = {
  expanded: {
    width: "333%",
    height: "1300px",
    borderRadius: "25%",
    transform: "rotate(190deg)",
  },
  collapsed: {
    width: "125%",
    height: "650px",
    borderRadius: "60%",
    transform: "rotate(60deg)"
  }
};

const expandingTransition ={
  type: "spring",
  duration: 2.3,
  stiffness: 30,
};

export function AccountBox(props) {
  const [isExpanded, setExpanded] = useState(false);
  const [active, setActive] = useState("signin");

  const playExpandingAnimation = () => {
    setExpanded(true);
    setTimeout(() => {
      setExpanded(false);
    }, expandingTransition.duration * 1000 - 1500);
  }

  const switchToSignup = () => {
    playExpandingAnimation();
    setTimeout(() => {
      setActive("signup")
    }, 400)
  }

  const switchToSignin = () => {
    playExpandingAnimation();
    setTimeout(() => {
      setActive("signin")
    }, 400)
  }

  const contextValue = { switchToSignup, switchToSignin };

  return(
    <AccountContext.Provider value={contextValue}>
      <BoxContainer>
        <TopContainer>
          <BackDrop 
          initial={false} 
          animate={isExpanded ? "expanded" : "collapsed"} 
          variants={backdropVariants}
          transition={expandingTransition}
          />
          {active === "signin" && <HeaderContainer>
            
            <HeaderText>ChatApp</HeaderText>
          </HeaderContainer>}
          {active === "signup" && <HeaderContainer>
            
            <HeaderText>ChatApp</HeaderText>
          </HeaderContainer>}
        </TopContainer>
        <InnerContainer>
          {active === "signin" && <LoginForm />}
          {active === "signup" && <SignUpForm />}
        </InnerContainer>
      </BoxContainer>
    </AccountContext.Provider>
  )
}
