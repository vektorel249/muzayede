import axios from "axios";

const token = localStorage.getItem('authToken');

// let obj = {
//     'Content-Type': "application/json"
// }

// if (token) {
//     obj.Authorization = "Bearer sdfsdjflsdfjk";
// }

const api = axios.create({
  baseURL: 'https://localhost:7088',
  headers: {
    'Content-Type': 'application/json',
    ...(token && { Authorization: `Bearer ${token}` }) // tüm diğer header değerleri üstüne token varsa bir de Authorization'ı ekle
  }
});

const configuration = {
    timeout: 8000
};

const ajax = () => {
    return {
        get: async function (url) {
            const response = await api.get(url, configuration);
            return await Promise.resolve(response.data);
        },
        post: function (url, content, ) {
            return api.post(url, content, configuration).then(response => {
                return Promise.resolve(response.data); // ~Task.FromResult<T>(data)
            }).catch(e => {
                return Promise.reject(e);
            })
        }
    }
};
export default ajax();