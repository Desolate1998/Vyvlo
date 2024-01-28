import { ErrorOr } from "../../../Types/ErrorOr";
import { createProductCategoryRequest } from "../../../Types/CreateProductCategoryRequest";
import { requests } from "../../agnet";
import { CategoriesWithStats } from "../../../Types/GetAllCategoriesWithStats";
import { UpdateProductCategoryRequest } from "../../../Types/UpdateProductCategoryRequest";

export const productCategoryApi = {
    create: (data: createProductCategoryRequest) => requests.post<ErrorOr<boolean>>(`ProductCategory/create`, data),
    getAllCategoriesWithStats: (storeId:number) => requests.get<ErrorOr<CategoriesWithStats[]>>(`ProductCategory/CategoriesWithStats?storeId=${storeId}`),
    updateCategory:(data:UpdateProductCategoryRequest)=> requests.post<ErrorOr<ProductCategory>>(`ProductCategory/Update`,data),
    deleteCategory:(id:number)=> requests.post<ErrorOr<boolean>>(`ProductCategory/Delete`,{id:id}),
    getAllCategories:(storeId:number)=> requests.get<ErrorOr<ProductCategory[]>>(`ProductCategory/GetAllCategories?storeId=${storeId}`),
}