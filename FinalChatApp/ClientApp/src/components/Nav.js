import React from "react";
import { Link } from "react-router-dom";

const Nav = () => {
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
            <Link to="register" class="nav-link">
              Register
            </Link>
          </li>
          <li class="nav-item">
            <Link to="login" class="nav-link">
              Sign in
            </Link>
          </li>
          {/* <li class="nav-item">
            <Link class="nav-link">Logout</Link>
          </li> */}
        </ul>
      </div>
    </nav>
  );
};

export default Nav;
