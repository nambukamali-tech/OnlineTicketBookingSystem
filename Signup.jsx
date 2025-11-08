import React from "react";
import "./Signup.css";
function Signup()
{
    return(
       <div className="signup-container">
        <div className="signup-box">
            <h4>Hey New Traveller ! Please Fill the Details to Signup</h4>
            <form>
                <div className="form-group">
                    <label>Enter your FirstName</label>
                    <input type="text" placeholder="FirstName.."required/>
                </div>
                <div className="form-group">
                    <label>Enter your LastName</label>
                    <input type="text" placeholder="LastName"required/>
                </div>
                <div className="form-group">
                    <label>Enter your Email Address</label>
                    <input type="text" placeholder="Email"required/>
                </div>
                <div className="form-group">
                    <label>Enter your Password</label>
                    <input type="text" placeholder="Password"required/>
                </div>
                <div className="form-group">
                    <label>Confirm Your Password</label>
                    <input type="text" placeholder="Confirm Password"required/>
                </div>
                <button type="submit" className="signup-button">SIGNUP</button>
                <p className="login-link">Already have an account ? Please Login here <a href="/Login">LOGIN</a></p>
            </form>
        </div>
       </div>
    );
}
export default Signup;