import axios from 'axios';

const baseURL = 'https://localhost:7026/api';

export const login = async (credentials) => {
    return axios.post(`${baseURL}/AuthApi`, credentials);
};

export const getPosts = async (token) => {
    return axios.get(`${baseURL}/BlogApi`, {
        headers: {
            Authorization: `Bearer ${token}`,
        },
    });
};
