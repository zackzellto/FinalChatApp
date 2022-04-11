import React from "react";
import styled from "styled-components";

export const HeaderText = styled.h2`
  font-family: "Akaya Telivigala";
  font-size: 300px;
  font-weight: 600;
  line-height: 1.24;
  color: #fff;
  z-index: 10;
  margin: 0;
  margin-right: 3em;
  position: relative;
  top: 40px;
  left: 20%;
  filter: drop-shadow(6px 6px 5px black);
`;

const Home = () => {
  return <HeaderText>ChatApp</HeaderText>;
};

export default Home;
