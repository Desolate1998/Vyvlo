import { ErrorOr } from "../../../Types/ErrorOr";
import { CreateStoreRequest } from "../../../Types/CreateStoreRequest";
import { KeyValuePair } from "../../../Types/KeyValuePair";
import { Store } from "../../../Types/Store";
import { requests } from "../../agnet";

export const storeApi = {
    create: (data: FormData) => requests.post<ErrorOr<Store>>(`store/create`, data),
    getUserOwnedStoreNames: () => requests.get<ErrorOr<KeyValuePair<number, string>[]>>(`store/getUserOwnedStoreNames`)
}