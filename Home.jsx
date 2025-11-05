import React from "react";
import "./Home.css";//Import the CSS Styles here
function Home()
{
    return(
        <div className = "home-container">
            <section className="top-section">
                <div className="top-section-content">
                 <h1>Book Your Tickets Easy ! Make your Journey Classy !</h1>
                 <p>We are here, Book your Tickets Instantly , Gain the Travel Experience Peacefully!!</p>
                 <button className="book-btn">Book Now</button>
                </div>
                <div className="top-section-image">
                    <img src="/images/top-banner-1st.jpg" alt="top-content-image" />

                </div>

            </section>

        </div>

    );
}
export default Home;