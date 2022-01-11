import React from "react";
import "../style/NavBar.css";
import {NavLink} from "react-router-dom";

const Navbar = ({ sticky }) => {
    return (
        <nav className={sticky ? "navbar navbar-sticky" : "navbar"}>
            <div className="header">
                <h1> Superviseur Frontend</h1>
            </div>
            <ul className="navbar--link">
                <NavLink className="navbar--link-item" to="/bankTransfer">BankTransfer</NavLink>
                <NavLink className="navbar--link-item" to="/user">User</NavLink>
                <NavLink className="navbar--link-item" to="/account">Account</NavLink>
            </ul>
        </nav>
    )};
export default Navbar;