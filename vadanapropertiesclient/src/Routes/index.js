import React from 'react';
import { Routes, Route } from 'react-router-dom';
import SignIn from '../Views/SignIn';
import AllListings from '../Views/AllListings';
import Contact from '../Views/Contact';
import CreateListings from '../Views/CreateListings';
import EditListings from '../Views/EditListings';
import FavoriteListings from '../Views/FavoriteListings';
import ListingsDetails from '../Views/ListingsDetails';
import NewRealtor from '../Views/NewAgent';
import NewListing from '../Views/NewListing';
import AllRealtors from '../Views/AllRealtors';


export default function Routing() {
    return (
            <Routes>
                <Route exact path="/" element={<SignIn />} />
                <Route exact path="/home" element={<Home />} />
                <Route exact path="/about" element={<About />} />
                <Route exact path="/allListings" element={<AllListings />} />
                <Route exact path="/contact" element={<Contact />} />
                <Route exact path="/createListings" element={<CreateListings />} />
                <Route exact path="/editListings" element={<EditListings />} />
                <Route exact path="/favoriteListings" element={<FavoriteListings />} />
                <Route exact path="/listingsDetails" element={<ListingsDetails />} />
                <Route exact path="/newRealtor" element={<NewRealtor />} />
                <Route exact path="/newListing" element={<NewListing />} />
                <Route exact path="/allRealtors" element={<AllRealtors />} />
            </Routes>
        
    )
}