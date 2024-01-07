import { ErrorOr } from "../../../../Domain/Contracts/ErrorOr";
import { createStoreRequest } from "../../../../Domain/Contracts/store/CreateStore/createStoreRequest";
import { KeyValuePair } from "../../../../Domain/Types/Common/keyValuePair";
import { Store } from "../../../../Domain/Types/Database Entities/store";
import { requests } from "../../agnet";

export const storeApi = {
    create: (data: createStoreRequest) => requests.post<ErrorOr<Store>>(`store/create`, data),
    getUserOwnedStoreNames: () => requests.get<ErrorOr<KeyValuePair<number, string>[]>>(`store/getUserOwnedStoreNames`)
}