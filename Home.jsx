import React from "react";
import { FaLinkedin, FaGithub, FaPlane } from "react-icons/fa";
import "./Home.css";

function Home() {
  return (
    <div className="home-page">
      {/* Floating gradient shapes */}
      <div className="shapes">
        <div className="shape shape1"></div>
        <div className="shape shape2"></div>
        <div className="shape shape3"></div>
        <div className="shape shape4"></div>
        <div className="shape shape5"></div>
      </div>

      {/* Navbar */}
      <nav className="nav-bar">
        <p className="nav-logo">
          TICKETRY <FaPlane style={{ marginLeft: "10px", color: "#38bdf8" }} />
        </p>
        <ul className="nav-links">
          <li><a href="/Admin">Admin</a></li>
          <li><a href="/">Home</a></li>
          <li><a href="/Login">Login</a></li>
          <li><a href="/Signup">Signup</a></li>
        </ul>
      </nav>

      {/* Hero Content */}
      <div className="hero-section">
        <h1 className="hero-title">Book Your Tickets Easy!</h1>
        <p className="hero-subtitle">
          Make your Journey Classy with us ..!
        </p>

        
  
      </div>

      {/* Footer */}
      <footer className="footer-page">
        <div className="footer-content">
          <h5>Follow Us</h5>
          <div className="social-links">
            <a href="https://www.linkedin.com/in/nambu-kamali-531233265/" target="_blank" rel="noopener noreferrer">
              <FaLinkedin />
            </a>
            <a href="https://github.com/nambukamali-tech" target="_blank" rel="noopener noreferrer">
              <FaGithub />
            </a>
          </div>
          <p>All rights Reserved @NambuKamali | Ticketry</p>
        </div>
      </footer>
    </div>
  );
}

export default Home;
