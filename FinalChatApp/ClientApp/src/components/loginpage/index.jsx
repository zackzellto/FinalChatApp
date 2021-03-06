import styled from "styled-components";

import { motion } from "framer-motion";

export const BoxContainer = styled.div`
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

export const BoxContainerUI = styled.div`
  filter: drop-shadow(16px 16px 10px black);
  width: px;
  min-height: 750px;
  display: flex;
  flex-direction: column;
  border-radius: 16px;
  background-color: #fff;
  box-shadow: 0 0 5px rgba(15, 15, 15, 0.28);
  position: relative;
  overflow: hidden;
`;

export const TopContainer = styled.div`
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  padding: 0 1.8em;
  padding-bottom: 5em;
`;

export const BackDrop = styled(motion.div)`
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
  background: linear-gradient(
    90deg,
    rgba(2, 0, 36, 1) 0%,
    rgba(9, 9, 121, 1) 35%,
    rgba(0, 212, 255, 1) 100%
  );
  z-index: 10;
`;

export const HeaderContainer = styled.div`
  width: 100%;
  display: flex;
  flex-direction: column;
`;

export const HeaderText = styled.h2`
  font-family: "Akaya Telivigala";
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

export const InnerContainer = styled.div`
  width: 100%;
  display: flex;
  flex-direction: column;
  padding: 1em;
`;

export const backdropVariants = {
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
    transform: "rotate(60deg)",
  },
};

export const expandingTransition = {
  type: "spring",
  duration: 2.3,
  stiffness: 30,
};
