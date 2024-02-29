import { StoreStatus } from "./StoreStatus";

export type Store = {
    storeID: number;
    storeOwnerID: number;
    storeName: string;
    storeAddress?: string;
    storeStatusCode: string;
    storePhoneNumber?: string;
    storeEmail?: string;
    storeDescription: string;
    createdAt: Date;
    storeStatus: StoreStatus;
}