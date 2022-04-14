import "./App.css";
import { useEffect, useState } from "react";
import { ChatApp } from "./components/chat-app";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { SignUpForm } from "./components/loginpage/signUpForm";
import LoginForm from "./components/loginpage/loginForm";
import history from "./history";
import Home from "./components/home";
import Nav from "./components/Nav";

function App() {
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
