import { ErrorOr } from "../../../Types/ErrorOr";
import { createStoreRequest } from "../../../Types/createStoreRequest";
import { KeyValuePair } from "../../../Types/keyValuePair";
import { Store } from "../../../Types/store";
import { requests } from "../../agnet";

export const storeApi = {
    create: (data: createStoreRequest) => requests.post<ErrorOr<Store>>(`store/create`, data),
    getUserOwnedStoreNames: () => requests.get<ErrorOr<KeyValuePair<number, string>[]>>(`store/getUserOwnedStoreNames`)
}