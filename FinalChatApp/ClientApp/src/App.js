import "./App.css";
import { ChatApp } from "./components/chat-app";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { SignUpForm } from "./components/loginpage/signUpForm";
import LoginForm from "./components/loginpage/loginForm";
import history from "./history";
import Home from "./components/home";

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <BrowserRouter history={history}>
          <Routes>
            <Route path="/" exact element={<Home />}></Route>
            <Route path="/signin" element={<LoginForm />}></Route>
            <Route path="/signup" element={<SignUpForm />}></Route>
            <Route path="/chat" element={<ChatApp />} />
          </Routes>
        </BrowserRouter>
      </header>
    </div>
  );
}

export default App;
