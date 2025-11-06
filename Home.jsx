import React from "react";
import "./Home.css";//Import the CSS Styles here
import { FaLinkedin, FaGithub} from "react-icons/fa";
import { FaPlane } from "react-icons/fa";//Using Flight Icon near Ticketry

function Home()
{
    return(
        <div className = "home-container">
            <nav className="nav-bar">
                <p className="nav-logo">TICKETRY<FaPlane style={{marginLeft:"18px" , color:"pink"}}/></p>
                <ul className="nav-links">
                    <li><a href="/Admin">Admin</a></li>
                    <li><a href="/">Home</a></li>
                    <li><a href="/Login">Login</a></li>
                    <li><a href="/Signup">Signup</a></li>
                </ul>  
            </nav>
            
            <section className="top-section">
                <div className="top-section-content">
                 <h1>Book Your Tickets Easy!</h1>
                    <h1>Make your Journey Classy!</h1>
                 <p>We are here, Book your Tickets Instantly , Gain the Travel Experience Peacefully!!</p>
                 <button className="book-btn">Book Now</button>
                </div>
                {/*Using Bootstrap for Making Images in Carousel*/}
                <div className="top-section-image">
                    <div className="top-section-image">
                <div id="heroCarousel" className="carousel slide" data-bs-ride="carousel">
                 <div className="carousel-inner">
                 <div className="carousel-item active">
                <img src="/images/top-banner-1st.jpg"className="d-block w-100"alt="Ticketry"/>
                </div>
                {/*Showing Second Image in carousel*/}
               <div className="carousel-item">
               <img src="/images/top-banner-2nd.jpg"className="d-block w-100" alt="Ticketry"/>
               </div>
               {/*Showing Third Image in carousel*/}
               <div className="carousel-item">
               <img src="/images/top-banner-3rd.jpg" className="d-block w-100" alt="Ticketry"/>
            </div>
            </div>

             {/* Carousel controls */}
             <button className="carousel-control-prev"type="button" data-bs-target="#heroCarousel"
             data-bs-slide="prev">
             <span className="carousel-control-prev-icon" aria-hidden="true"></span>
            <span className="visually-hidden">Previous</span>
            </button>
            <button className="carousel-control-next" type="button" data-bs-target="#heroCarousel" data-bs-slide="next">
            <span className="carousel-control-next-icon" aria-hidden="true"></span>
            <span className="visually-hidden">Next</span>
            </button>
            </div>
        </div>
       </div>

         </section>

            {/*Footer Section*/}
            <footer className="footer-page">
            <div className="text-center">
            <h5 style={{fontFamily:"cursive"}}>Follow Us</h5>
            <div style={{ display: "flex", justifyContent: "center", gap: "25px", marginTop: "15px" }}>
            <a
              href="https://www.linkedin.com/in/nambu-kamali-531233265/"
              target="_blank"
              rel="noopener noreferrer"
              style={{ color: "#0A66C2", fontSize: "30px" }}
            >
              <FaLinkedin />{/*Using Bootstrap for Icons Linkedin and Github*/}
            </a>
             <a
              href="https://github.com/nambukamali-tech"
              target="_blank"
              rel="noopener noreferrer"
              style={{ color: "white", fontSize: "30px" }}
            >
              <FaGithub />
            </a>
            <p style={{marginTop : "20px", fontSize: "14px"}}>All rights Reserved @NambuKamali|Ticketry</p>
            </div>
            </div>
            </footer>

        </div>

    );
}
export default Home;
