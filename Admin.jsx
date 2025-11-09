import React from "react";
import "./Admin.css";
function Admin()
{
    return(
        <div className="admin-container">
            <aside className="admin-sidebar">
                <h2 className="sidebar-title">Welcome Admin !</h2>
                <ul className="sidebar-links">
                    <li><a href="#">Dashboard</a></li>
                    <li><a href="#">Manage Users</a></li>
                    <li><a href="#">View Bookings</a></li>
                    <li><a href="#">Reviews</a></li>
                    <li><a href="/home">Logout</a></li>
                    
                </ul>
            </aside>
            <main className="admin-main">
                <h1>Admin Activity..</h1>
                <p>Here you can manage all the Users Activities , Reports , Bookings ..</p>
                <div className="admin-cards">
                    <div className="cards">
                        <h4>Bookings Today !</h4>
                        <p>Total : 200</p>
                    </div>
                    <div className="cards">
                        <h4>Total Users</h4>
                        <p>230</p>
                    </div>
                    <div className="cards">
                        <h4>Total Revenue Today !</h4>
                        <p> ₹20000</p>
                    </div>
                </div>
            </main>
        </div>

    );
}
export default Admin;