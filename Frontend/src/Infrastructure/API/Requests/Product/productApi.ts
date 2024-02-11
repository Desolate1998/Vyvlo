import { ErrorOr } from "../../../Types/ErrorOr";
import { requests } from "../../agnet";

export const productApi = {
    create: (data: FormData) => requests.post<ErrorOr<boolean>>(`Product/create`, data),
}