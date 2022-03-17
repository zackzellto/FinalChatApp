import "./App.css";
import styled from "styled-components";
import { AccountBox } from "./components/loginpage";
import { ChatApp } from "./components/chat-app";
import { BrowserRouter, Route, Routes } from "react-router-dom";

const AppContainer = styled.div`
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
`;

function App() {
  return (
    <div className="App">
      <header className="App-header"></header>
    </div>
  );
}

export default App;
