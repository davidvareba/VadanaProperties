import axios from 'axios';

const baseURL = "https://localhost:7013/api/Realtors";

const getAllRealtors = () => new Promise((resolve, reject) => {
    axios.get(`${baseURL}`)
        .then((response) => resolve(Object.values(response.data)))
        .catch(reject);
});

//current return type is object, may need to be updated later depending on usage
const getRealtorById = (id) => new Promise((resolve, reject) => {
    axios.get(`${baseURL}/Agents/${id}`)
        .then((response) => resolve(response.data))
        .catch(reject);
});

export {
    getAllRealtors,
    getRealtorById,
};