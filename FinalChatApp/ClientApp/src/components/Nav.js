import { React } from "react";
import { Link } from "react-router-dom";

const Nav = (props) => {
  const logout = async () => {
    fetch("https://localhost:7089/api/logout", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      credentials: "include",
    });
    props.setUsername("");
  };

  let navMenu;

  if (props.username === "") {
    navMenu = (
      <ul class="navbar-nav ms-auto">
        <li class="nav-item">
          <Link to="register" class="nav-link">
            Register
          </Link>
        </li>
        <li class="nav-item">
          <Link to="login" class="nav-link">
            Login
          </Link>
        </li>
      </ul>
    );
  } else {
    navMenu = (
      <ul class="navbar-nav ms-auto">
        <li class="nav-item">
          <Link to="login" class="nav-link" onClick={logout}>
            Logout
          </Link>
        </li>
      </ul>
    );
  }

  return (
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <Link to="/" class="navbar-brand">
        Chat App
      </Link>
      <button
        class="navbar-toggler"
        type="button"
        data-toggle="collapse"
        data-target="#navbarNav"
        aria-controls="navbarNav"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarNav">
        <ul class="navbar-nav ms-auto">
          <li class="nav-item">
            <div class="nav-link">You are not logged in</div>
          </li>
          <li class="nav-item">
            <Link to="register" class="nav-link">
              Register
            </Link>
          </li>
          <li class="nav-item">
            <Link to="login" class="nav-link">
              Login
            </Link>
          </li>
        </ul>
      </div>
    </nav>
  );
};

export default Nav;
