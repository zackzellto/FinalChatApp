import { Container, Col, Row, Button, Form } from "react-bootstrap";

function ChatAppUI() {
  return (
    <Container>
      <Row>
        <Col id="title-bar" md={12}>
          Chat App
        </Col>
      </Row>{" "}
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

          <Button className="btn btn-info me-md" variant="info" btn-block>
            Send
          </Button>
        </div>
      </Row>
    </Container>
  );
}

export default ChatAppUI;
