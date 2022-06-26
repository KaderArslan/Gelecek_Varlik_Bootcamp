import axios from 'axios';

const BASE_URL = 'http://localhost:54620';

// export default axios.create({
//     baseURL: 'http://localhost:80'
// });

export default axios.create({
    baseURL: BASE_URL
});

export const axiosPrivate = axios.create({
    baseURL: BASE_URL,
    headers: { 'Content-Type': 'application/json' },
    withCredentials: true
});