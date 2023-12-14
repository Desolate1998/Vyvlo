import { loginRequest } from "../../../../Domain/Contracts/Authentication/Login/loginRequest"
import { loginResponse } from "../../../../Domain/Contracts/Authentication/Login/loginResponse"
import { registerRequest } from "../../../../Domain/Contracts/Authentication/Register/registerRequest"
import { registerResponse } from "../../../../Domain/Contracts/Authentication/Register/registerResponse"
import { ErrorOr } from "../../../../Domain/Contracts/ErrorOr"
import { requests } from "../../agnet"

export const authenticationApi = {
    login: (data: loginRequest) => requests.post<ErrorOr<loginResponse>>(`auth/login`, data),
    register: (data: registerRequest) => requests.post<ErrorOr<registerResponse>>(`auth/Register`, data)
}