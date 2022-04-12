import "./App.css";
import { ChatApp } from "./components/chat-app";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { SignUpForm } from "./components/loginpage/signUpForm";
import LoginForm from "./components/loginpage/loginForm";
import history from "./history";
import Home from "./components/home";
import Nav from "./components/Nav";

function App() {
  return (
    <div className="App">
      <BrowserRouter history={history}>
        <Nav />
        <header className="App-header">
          <Routes>
            <Route path="/" exact element={<Home />}></Route>
            <Route path="/login" element={<LoginForm />}></Route>
            <Route path="/register" element={<SignUpForm />}></Route>
            <Route path="/chat" element={<ChatApp />} />
          </Routes>
        </header>
      </BrowserRouter>
    </div>
  );
}

export default App;
