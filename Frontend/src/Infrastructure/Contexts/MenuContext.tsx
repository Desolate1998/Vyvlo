import React, { createContext, useContext, useState, ReactNode } from "react";

interface MenuContextProps {
  isMenuOpen: boolean;
  changeMenu: () => void;
  page: string;
  changePage: ( pageName: string) => void;
}

const MenuContext = createContext<MenuContextProps | undefined>(undefined);

interface MenuProviderProps {
  children: ReactNode;
}

export const MenuProvider: React.FC<MenuProviderProps> = ({ children }) => {
  const [isMenuOpen, setIsMenuOpen] = useState(true);
  const [page, setPageName] = useState("");

  const changeMenu = () => setIsMenuOpen(!isMenuOpen);

  const changePage = ( pageName: string) => {
    setPageName(pageName);
  };



  return (
    <MenuContext.Provider
      value={{ isMenuOpen, changeMenu, page, changePage}}
    >
      {children}
    </MenuContext.Provider>
  );
};

export const useMenu = (): MenuContextProps => {
  const context = useContext(MenuContext);
  if (!context) {
    throw new Error("useMenu must be used within a MenuProvider");
  }
  return context;
};
