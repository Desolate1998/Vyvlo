import { LoginRequest } from "../../../Types/LoginRequest"
import { LoginResponse } from "../../../Types/LoginResponse"
import { RegisterRequest } from "../../../Types/RegisterRequest"
import { registerResponse } from "../../../Types/RegisterResponse"
import { ErrorOr } from "../../../Types/ErrorOr"
import { requests } from "../../agnet"

export const authenticationApi = {
    login: (data: LoginRequest) => requests.post<ErrorOr<LoginResponse>>(`auth/login`, data),
    register: (data: RegisterRequest) => requests.post<ErrorOr<registerResponse>>(`auth/Register`, data)
}