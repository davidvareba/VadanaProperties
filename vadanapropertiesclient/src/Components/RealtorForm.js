import React, { useState } from 'react'

const initialState = {
    picture: '',
    name: '',
    phone: '',
    email: '',
    username: '',
    password: '',
}

export default function RealtorForm() {
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
            <label htmlFor='picture'>
                Img Url:
                <input type='text' id='picture' value={formInput.imgUrl || ''} onChange={handleChange} />
            </label>
            <label htmlFor='name'>
                Name:
                <input type='text' id='name' value={formInput.name || ''} onChange={handleChange} />
            </label>
            <label htmlFor='phone'>
                Phone Number:
                <input type='text' id='phone' value={formInput.phone || ''} onChange={handleChange} />
            </label>
            <label htmlFor='email'>
                Email:
                <input type='text' id='phoneNum' value={formInput.email || ''} onChange={handleChange} />
            </label>
            <label htmlFor='email'>
                Username:
                <input type='text' id='email' value={formInput.username || ''} onChange={handleChange} />
            </label>
            <label htmlFor='password'>
                Password:
                <input type='text' id='password' value={formInput.password || ''} onChange={handleChange} />
            </label>
            <input type="submit" value="Submit" />
        </form>
    )
}
