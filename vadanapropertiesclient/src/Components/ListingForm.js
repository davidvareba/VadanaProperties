import React, { useState } from 'react'

const initialState = {
    address: '',
    description: '',
    rent: '',
    squareFoot: '',
    yearBuilt: '', 
    city: '',
    realtor: '',
}

export default function ListingForm() {
    const [formInput, setFormInput] = useState(initialState);

    const handleChange = (e) => {
        setFormInput((prevState) => ({
            ...prevState,
            [e.target.id]: e.target.value,
        }));
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        console.warn(formInput);
    }

    return (
        <form onSubmit={handleSubmit}>
            <label htmlFor="address">
                Address:
                <input type="text" id="address" value={formInput.address || ""} onChange={handleChange} />
            </label>
            <label htmlFor="description">
                Description:
                <input type="text" id="description" value={formInput.description || ""} onChange={handleChange} />
            </label>
            <label htmlFor="rent">
                Rent:
                <input type="text" id="rent" value={formInput.rent || ""} onChange={handleChange} />
            </label>
            <label htmlFor="squareFoot">
                Square Foot:
                <input type="text" id="squareFoot" value={formInput.squareFoot || ""} onChange={handleChange} />
            </label>
            <label htmlFor="yearBuilt">
                Year Built:
                <input type="text" id="yearBuilt" value={formInput.yearBuilt || ""} onChange={handleChange} />
            </label>
            <label htmlFor="city">
                City:
                <input type="text" id="city" value={formInput.city || ""} onChange={handleChange} />
            </label>
            <label htmlFor="agent">
                Realtor:
                <input type="text" id="realtor" value={formInput.realtor || ""} onChange={handleChange} />
            </label>
            <input type="submit" value="Submit" />
        </form>
    )
}
