import React from 'react';
import { Link } from 'react-router-dom';
import { signOutUser } from '../Data/Auth';


export default function Navbar()
{
    return (
        <div>
            <nav variant="tabs" className="navbar navbar-expand-lg navbar-light bg-light">
                <div className="container-fluid">
                    <Link className="navbar-brand fas fa-home" to="/home">
                        Home
                    </Link>
                    <button
                        className="navbar-toggler"
                        type="button"
                        data-bs-toggle="collapse"
                        data-bs-target="#navbarSupportedContent"
                        aria-controls="navbarSupportedContent"
                        aria-expanded="false"
                        aria-label="Toggle navigation"
                    >
                        <span className="navbar-toggler-icon" />
                    </button>
                    <div className="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                            <li className="nav-item">
                                <Link className="nav-link active" to="/about">
                                    About Vadana Properties
                                </Link>
                            </li>
                            <li className="nav-item">
                                <Link className="nav-link active" to="/listings">
                                    Our Listings
                                </Link>
                            </li>
                            <li className="nav-item">
                                <Link className="nav-link active" to="/realtors">
                                    Our Realtors
                                </Link>
                            </li>
                            <li className="nav-item">
                                <Link className="nav-link active" to="/favorite">
                                    Favorite Listings
                                </Link>
                            </li>
                            <li className="nav-item">
                                <Link className="nav-link active" to="/contact">
                                    Contact Us
                                </Link>
                            </li>
                            <li className="nav-item">
                                <button
                                    onClick={signOutUser}
                                    type="button"
                                    className="nav-link active btn btn-link"
                                >
                                    Logout
                                </button>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        </div>

        );
};