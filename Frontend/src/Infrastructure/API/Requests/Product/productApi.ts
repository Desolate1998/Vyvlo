import { ErrorOr } from "../../../Types/ErrorOr";
import { requests } from "../../agnet";

export const productCategoryApi = {
    create: (data: FormData) => requests.post<ErrorOr<boolean>>(`ProductCategory/create`, data),
}