import React, { createContext, useContext, useState, ReactNode } from 'react';

// Define types for the context
interface MenuContextProps {
  isMenuOpen: boolean;
  changeMenu: () => void;
}

// Create a context
const MenuContext = createContext<MenuContextProps | undefined>(undefined);

// Create a provider component
interface MenuProviderProps {
  children: ReactNode;
}

export const MenuProvider: React.FC<MenuProviderProps> = ({ children }) => {
  const [isMenuOpen, setIsMenuOpen] = useState(true);

  const changeMenu = () => {
    setIsMenuOpen(!isMenuOpen);
  };



  return (
    <MenuContext.Provider value={{ isMenuOpen, changeMenu}}>
      {children}
    </MenuContext.Provider>
  );
};

// Create a custom hook to use the context
export const useMenu = (): MenuContextProps => {
  const context = useContext(MenuContext);
  if (!context) {
    throw new Error('useMenu must be used within a MenuProvider');
  }
  return context;
};
