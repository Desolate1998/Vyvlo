import { loginRequest } from "../../../Types/loginRequest"
import { loginResponse } from "../../../Types/loginResponse"
import { registerRequest } from "../../../Types/registerRequest"
import { registerResponse } from "../../../Types/registerResponse"
import { ErrorOr } from "../../../Types/ErrorOr"
import { requests } from "../../agnet"

export const authenticationApi = {
    login: (data: loginRequest) => requests.post<ErrorOr<loginResponse>>(`auth/login`, data),
    register: (data: registerRequest) => requests.post<ErrorOr<registerResponse>>(`auth/Register`, data)
}