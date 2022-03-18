import "./App.css";
import { AccountBox } from "./components/loginpage/index.jsx";
import { ChatApp } from "./components/chat-app";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { SignUpForm } from "./components/loginpage/signUpForm";
import LoginForm from "./components/loginpage/loginForm";

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
