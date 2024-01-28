import React, { createContext, useContext, useState, ReactNode } from "react";
import { KeyValuePair } from "../Types/keyValuePair";
import { storeApi } from "../API/Requests/Store/storeApi";
interface StoreContextProps {
    currentStoreId: number | null;
    setCurrentStoreId: (storeId: number) => void;
    stores: KeyValuePair<number, string>[];
    getStores: () => void;
    getCurrentStoreName: () => string;  
}

const StoreContext = createContext<StoreContextProps | undefined>(undefined);

interface StoreProviderProps {
    children: ReactNode;
}

export const StoreProvider: React.FC<StoreProviderProps> = ({ children }) => {
    const [currentStoreId, setCurrentStoreId] = useState<number | null>(null);
    const [stores, setStores] = useState<KeyValuePair<number, string>[]>([]);
    const [listeners,setListener] = useState<(()=>void)[]>([])

    const getStores = async () => {
        var res = await storeApi.getUserOwnedStoreNames();
        if (res.isError) {
        } else {
            if (res.value.length !== 0) {
                setStores(res.value);
                setCurrentStoreId(res.value[0].key);
            } 
        }
    }

    const regesterStoreChangeEvent = (callback:()=>void)=>setListener([...listeners,callback])

    const deRegisterStoreChangeEvent = (id:string)=>setListener(listeners.filter(x=>x.name!==id))
    
    const notifyListeners = () => listeners.forEach(x=>x())
    

    const getCurrentStoreName = (): string => {
        if (currentStoreId != null) {
            var store = stores.find(x => x.key == currentStoreId);
            if (store != null) {
                return store.value;
            }
        }
        return '';
    }

    return (
        <StoreContext.Provider value={{ currentStoreId, setCurrentStoreId, stores, getStores, getCurrentStoreName }}>
            {children}
        </StoreContext.Provider>
    );
};

export const useStore = (): StoreContextProps => {
    const context = useContext(StoreContext);
    if (!context) {
        throw new Error("useStore must be used within a MenuProvider");
    }
    return context;
};