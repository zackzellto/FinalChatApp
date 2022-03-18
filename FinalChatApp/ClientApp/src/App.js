import "./App.css";
import styled from "styled-components";
import { AccountBox } from "./components/loginpage";
import { ChatApp } from "./components/chat-app";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import LoginForm from "./components/loginpage/loginForm";
import { SignUpForm } from "./components/loginpage/signUpForm";

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
      <header className="App-header">
        <BrowserRouter>
          <Routes>
            <Route path="/signin" element={<AccountBox />}></Route>
            <Route path="/signup" element={<SignUpForm />}></Route>
            <Route path="/chat" element={<ChatApp />} />
          </Routes>
        </BrowserRouter>
      </header>
    </div>
  );
}

export default App;
