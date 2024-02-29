import { ErrorOr } from "../../../Types/ErrorOr";
import { requests } from "../../agnet";

export const productApi = {
    create: (data: FormData) => requests.post<ErrorOr<Product>>(`Product/create`, data),
    getAll: (storeId:number) => requests.get<ErrorOr<Product[]>>(`Product/GetAll?storeId=${storeId}`),
}