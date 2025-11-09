import React, {useState} from "react";
import "./Booking.css";
function Booking()
{
    //Change the Form from static to dynamic using useState
    const [form , setForm] =useState({
        TravelNo :"",
        From:"",
        To:"",
        Members:"",
        Price:"",
        Date:""
    });
    //Update Form Fields Dynamically
    const handleChange = (e) => {
        setForm({...form ,[e.target.name]: e.target.value});
    };
    //Calculate Total Amount Dynamically
    const total = form.Members && form.Price ? form.Members * form.Price : 0;
    //On Form Submit
    const handleSubmit = (e) => {
    e.preventDefault();
    alert(
        `Booking Successfull!
        ---------------------
        Travel ID : ${form.TravelNo}
        From : ${form.From} -> ${form.To}
        Members: ${form.Members}
        Price: ${form.Price}
        Total Amount: ${total}
        Date: ${form.Date}
        `);
    };
    return(
        <div className="booking-container">
            <div className="booking-card">
                <h3>Book Your Tickets!</h3>
                <form onSubmit={handleSubmit}>
                    <label>Travel ID</label>
                    <input type="text" name="TravelNo" value={form.TravelNo} onChange={handleChange}required/>
                    <label>Travel From</label>
                    <input type="text" name="From" value={form.From} onChange={handleChange} required/>
                    <label>Travel To</label>
                    <input type="text" name="To" value={form.To} onChange = {handleChange} required/>
                    <label>Members</label>
                    <input type="text" name="Members" value={form.Members} onChange={handleChange} min="1" required/>
                    <label>Price Per Ticket</label>
                    <input type="text" name="Price" value={form.Price} onChange={handleChange} min="0" required/>
                    <label>Date of Travel</label>
                    <input type="text" name="Date" value={form.Date} onChange={handleChange} required/>
                    {/* Display Total Price Amount */}
                    <div className="TotalPrice">
                        <strong>Total : ₹{total}</strong>
                    </div>
                    <button type="submit" className="book-btn">Book Now</button>

                </form>
            </div>
        </div>

    );

}
export default Booking;