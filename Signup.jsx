import React, { useState } from "react";
import "./Signup.css";

function Signup() {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");

  const API_URL = "http://localhost:44355/User/Signup"; // must match backend port

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!firstName || !lastName || !email || !password || !confirmPassword) {
      alert("Please fill all fields");
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
        body: JSON.stringify({ FirstName: firstName, LastName: lastName, Email: email, Password: password, ConfirmPassword: confirmPassword })
      });

      const data = await res.json();
      if (res.ok && data.success) alert(data.message);
      else alert(data.message || "Signup failed");
    } catch (err) {
      console.error("Network error:", err);
      alert("Network error: " + err.message);
    }
  };

  return (
    <div className="signup-container">
      <div className="signup-box">
        <h4>Hey New Traveller! Fill the Details to Signup</h4>
        <form onSubmit={handleSubmit}>
          <input type="text" placeholder="FirstName" value={firstName} onChange={e => setFirstName(e.target.value)} required />
          <input type="text" placeholder="LastName" value={lastName} onChange={e => setLastName(e.target.value)} required />
          <input type="email" placeholder="Email" value={email} onChange={e => setEmail(e.target.value)} required />
          <input type="password" placeholder="Password" value={password} onChange={e => setPassword(e.target.value)} required />
          <input type="password" placeholder="Confirm Password" value={confirmPassword} onChange={e => setConfirmPassword(e.target.value)} required />
          <button type="submit">SIGNUP</button>
        </form>
      </div>
    </div>
  );
}

export default Signup;
