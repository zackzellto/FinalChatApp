import { Col, Row, Button, Form } from "react-bootstrap";
import styled from "styled-components";

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

export function ChatApp() {
  return (
    <BoxContainer id="app-container">
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

          <Button className="btn btn-info me-md" variant="primary" btn-block>
            Send
          </Button>
        </div>
      </Row>
    </BoxContainer>
  );
}
