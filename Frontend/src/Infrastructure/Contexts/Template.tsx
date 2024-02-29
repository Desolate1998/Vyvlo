import React, { createContext, useContext, useState, ReactNode } from "react";
import { KeyValuePair } from "../Types/KeyValuePair";

interface ToasterContextProps {

}

const ToasterContext = createContext<ToasterContextProps | undefined>(undefined);

interface MenuProviderProps {
    children: ReactNode;
}

export const ToasterProvider: React.FC<MenuProviderProps> = ({ children }) => {

    return (
        <ToasterContext.Provider value={{}}>
            {children}
        </ToasterContext.Provider>
    );
};

export const useToaster = (): ToasterContextProps => {
    const context = useContext(ToasterContext);
    if (!context) {
        throw new Error("useToaster must be used within a MenuProvider");
    }
    return context;
};