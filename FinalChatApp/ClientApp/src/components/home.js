import { React, useEffect, useState } from "react";
import styled from "styled-components";

export const HeaderText = styled.h2`
  font-family: "Akaya Telivigala";
  font-size: 200px;
  font-weight: 600;
  line-height: 1.24;
  color: #fff;
  z-index: 10;
  margin: 0;
  margin-right: 3em;
  position: relative;

  left: 15%;
  filter: drop-shadow(6px 6px 5px black);
`;

const Home = () => {
  const [username, setUsername] = useState("");
  useEffect(() => {
    (async () => {
      const response = await fetch("https://localhost:7089/api/user", {
        headers: { "Content-Type": "application/json" },
        credentials: "include",
      });
      const content = await response.json();

      setUsername(content.username);
    })();
  });

  return (
    <>
      <HeaderText>Welcome to ChatApp</HeaderText>
    </>
  );
};

export default Home;
