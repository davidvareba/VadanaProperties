import axios from 'axios';

const baseURL = "https://localhost:7013/api";

const getAllRealtors = () => new Promise((resolve, reject) => {
    const token = sessionStorage.getItem("idToken");

    axios.get(`${baseURL}/Realtors`, {
        headers:{Authorization:"Bearer " + token }
    })
        .then((response) => resolve(Object.values(response.data)))
        .catch(reject);
});

//current return type is object, may need to be updated later depending on usage
const getRealtorById = (id) => new Promise((resolve, reject) => {
    axios.get(`${baseURL}/Realtors/${id}`)
        .then((response) => resolve(response.data))
        .catch(reject);
});

export {
    getAllRealtors,
    getRealtorById,
};