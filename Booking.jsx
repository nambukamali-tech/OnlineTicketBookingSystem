import React, { useState } from "react";
import "./Booking.css";
import { FaLinkedin, FaGithub, FaPlane } from "react-icons/fa";

function Booking() {
  const [form, setForm] = useState({
    TravelId: "",
    From: "",
    To: "",
    Members: "",
    Price: "",
    Date: ""
  });

  const handleChange = (e) => setForm({ ...form, [e.target.name]: e.target.value });
  const Total_Amount = form.Members && form.Price ? form.Members * form.Price : 0;
  const API_URL = "/Booking/SaveBooking"; // backend URL

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const res = await fetch(API_URL, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
          Travel_Id: form.TravelId,
          Travel_From: form.From,
          Travel_To: form.To,
          Members: form.Members,
          Price: form.Price,
          Total_Amount: Total_Amount,
          Date_of_Travel: form.Date
        }),
      });

      const data = await res.json();
      if (data.success) {
        alert(`Booking Saved Successfully!
Travel ID: ${form.TravelId}
From: ${form.From} -> ${form.To}
Members: ${form.Members}
Price: ₹${form.Price}
Total: ₹${Total_Amount}
Date: ${form.Date}`);
        setForm({ TravelId: "", From: "", To: "", Members: "", Price: "", Date: "" });
      } else {
        alert("Failed to save booking: " + (data.message || data.errors));
      }
    } catch (err) {
      console.error(err);
      alert("Server error: " + err.message);
    }
  };

  return (
      
          <div className="login-container">
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
    <div className="booking-container">
      <div className="booking-card">
        <h3>Book Your Tickets!</h3>
        <form onSubmit={handleSubmit}>
          <label>Travel ID</label>
          <input type="text" name="TravelId" value={form.TravelId} onChange={handleChange} required />
          <label>Travel From</label>
          <input type="text" name="From" value={form.From} onChange={handleChange} required />
          <label>Travel To</label>
          <input type="text" name="To" value={form.To} onChange={handleChange} required />
          <label>Members</label>
          <input type="number" name="Members" value={form.Members} onChange={handleChange} required />
          <label>Price</label>
          <input type="number" name="Price" value={form.Price} onChange={handleChange} required />
          <label>Date of Travel</label>
          <input type="date" name="Date" value={form.Date} onChange={handleChange} required />
          <div className="TotalPrice"><strong>Total: ₹{Total_Amount}</strong></div>
          <button className="book-btn">Book Now</button>
        </form>
      </div>
    </div>
   </div> 
   
  );
}
export default Booking;
