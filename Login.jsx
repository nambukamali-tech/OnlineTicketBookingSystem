import react from "react";
import "./Login.css";
function Login()
{
    return(   
        <div className="login-container">
            <div className="login-box">
                <h1>Login</h1>
                <p>Welcome to the Ticketry! Please Login to enter the Travel World!</p>
                <form className="login-form">
                    <div className="login-group">
                        <label>Email</label>
                        <input type="email" placeholder="Enter your Email ID" required/>
                    </div>
                    <div className="login-group">
                        <label>Password</label>
                        <input type="password" placeholder="Enter your Email Password" required/>
                    </div>
                    <button className="login-button"><a href="Booking">LOGIN</a></button>
                    <p className="signup-link">Don't have an account! Please <a href="Signup">SIGNUP</a></p>
                </form>
            </div>
        </div>

    );
}
export default Login;
