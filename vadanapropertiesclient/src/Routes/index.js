import React from 'react';
import { Routes, Route } from 'react-router-dom';
import Home from '../Views/Home';


export default function Routing() {
    return (
        <>
            <Routes>
                <Route exact path="/" element={<About />} />
                <Route exact path="/home" element={<Home />} />
            </Routes>
        </>
    )
}