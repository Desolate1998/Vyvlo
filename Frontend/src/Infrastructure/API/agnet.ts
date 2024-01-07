import axios, { AxiosResponse } from "axios";
axios.defaults.baseURL = "https://localhost:7261/";
const responseBody = <T>(response: AxiosResponse<T>) => response.data;

axios.interceptors.request.use(config => {
const user = localStorage.getItem('user');
if(user !== null){
    if(config.headers){
      config.headers.Authorization = `Bearer ${JSON.parse(user).token}`
    }
  }
  return config;
});


export const requests = {
  get: <T>(url: string) => axios.get<T>(url).then(responseBody),
  post: <T>(url: string, body:any) =>axios.post<T>(url, body).then(responseBody),
  put: <T>(url: string, body:any) =>axios.put<T>(url, body).then(responseBody),
}