import React, { useState } from "react";
import "./Signup.css";

function Signup() {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const API_URL = "https://localhost:44355/User/Signup"; 

  const handleSubmit = async (e) => {
    e.preventDefault();

    // Simple client-side validation
    if (!firstName || !lastName || !email || !password) {
      alert("Please fill all required fields");
      return;
    }
    if (password !== confirmPassword) {
      alert("Passwords do not match");
      return;
    }

    try {
      const res = await fetch(API_URL, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
          FirstName: firstName,
          LastName: lastName,
          Email: email,
          Password: password,
          ConfirmPassword: confirmPassword
        })
      });

      // If backend returns non-JSON or error status, handle it
      const data = await res.json().catch(() => ({ success: false, message: "Invalid response" }));

      if (res.ok && data.success) {
        alert(data.message || "Signup successful");
        // optionally clear form or navigate to login
      } else {
        alert(data.message || `Signup failed (status ${res.status})`);
      }
    } catch (err) {
      console.error("Network error:", err);
      alert("Network error: " + err.message);
    }
  };

  return (
    <div className="signup-container">
      <div className="signup-box">
        <h4>Hey New Traveller ! Please Fill the Details to Signup</h4>
        <form onSubmit={handleSubmit}>
          <div className="form-group">
            <label>Enter your FirstName</label>
            <input value={firstName} onChange={e => setFirstName(e.target.value)} type="text" placeholder="FirstName.." required />
          </div>
          <div className="form-group">
            <label>Enter your LastName</label>
            <input value={lastName} onChange={e => setLastName(e.target.value)} type="text" placeholder="LastName" required />
          </div>
          <div className="form-group">
            <label>Enter your Email Address</label>
            <input value={email} onChange={e => setEmail(e.target.value)} type="email" placeholder="Email" required />
          </div>
          <div className="form-group">
            <label>Enter your Password</label>
            <input value={password} onChange={e => setPassword(e.target.value)} type="password" placeholder="Password" required />
          </div>
          <div className="form-group">
            <label>Confirm Your Password</label>
            <input value={confirmPassword} onChange={e => setConfirmPassword(e.target.value)} type="password" placeholder="Confirm Password" required />
          </div>
          <button type="submit" className="signup-button">SIGNUP</button>
          <p className="login-link">Already have an account ? Please Login here <a href="/Login">LOGIN</a></p>
        </form>
      </div>
    </div>
  );
}

export default Signup;
