import { Col, Row, Button, Form } from "react-bootstrap";
import { useState } from "react";
import { motion } from "framer-motion";
import styled from "styled-components";

export const BoxContainer = styled.div`
  filter: drop-shadow(16px 16px 10px black);
  max-width: 90vw;
  width: 1300px;
  max-height: 90vh;
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
  filter: drop-shadow(36px 36px 35px black);
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
  margin-right: 8em;
  position: relative;
  top: 20px;
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
    width: "150%",
    height: "475px",
    borderRadius: "60%",
    transform: "rotate(169deg)",
  },
};

export const expandingTransition = {
  type: "spring",
  duration: 2.3,
  stiffness: 30,
};

export function ChatApp() {
  const [isExpanded, setExpanded] = useState(false);

  return (
    <BoxContainer>
      <TopContainer>
        <BackDrop
          initial={false}
          animate={isExpanded ? "expanded" : "collapsed"}
          variants={backdropVariants}
          transition={expandingTransition}
        />
        <HeaderContainer>
          <HeaderText id="header-text">ChatApp</HeaderText>
        </HeaderContainer>
        <InnerContainer>
          <Col id="conversations" md={{ span: 3, offset: 0 }}>
            Conversation Panel
          </Col>
          <Row>
            <Col id="message-display" md={{ span: 6, offset: 6 }}>
              Message Display
            </Col>
          </Row>
          <Row id="input-row">
            <div className="d-grid gap-3 d-md-flex justify-content-md-end">
              <Form id="message-input">
                <Form.Control
                  className="form-control-lg"
                  type="text"
                  placeholder="Send a message..."
                />
              </Form>

              <Button
                className="btn btn-info me-md"
                variant="primary"
                btn-block
              >
                Send
              </Button>
            </div>
          </Row>
        </InnerContainer>
      </TopContainer>
    </BoxContainer>
  );
}
