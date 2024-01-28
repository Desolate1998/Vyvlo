import React, { createContext, useContext, useState, ReactNode } from "react";
import { LightTheme } from "../Themes/lightTheme";
import { Theme } from "../Types/theme";
import { DarkTheme } from "../Themes/darkTheme";


interface ThemeContextProps {
    useDarkTheme: boolean;
    swapTheme: () => void;
    themeObject: Theme;
}

const ThemeContext = createContext<ThemeContextProps | undefined>(undefined);

interface ThemeProviderProps {
    children: ReactNode;
}

export const ThemeProvider: React.FC<ThemeProviderProps> = ({ children }) => {
    const [useDarkTheme, setUseDarkTheme] = useState<boolean>(false);
    const [themeStyle, setThemeStyle] = useState<Theme>(LightTheme)

    const swapTheme = () => {

        if (useDarkTheme) {
            document.body.style.background = LightTheme.backgroundColor
            setThemeStyle(LightTheme)
        } else {
            document.body.style.background = DarkTheme.backgroundColor
            setThemeStyle(DarkTheme)
        }
        setUseDarkTheme(!useDarkTheme)
    }

    return (
        <ThemeContext.Provider
            value={{
                swapTheme: swapTheme,
                useDarkTheme: useDarkTheme,
                themeObject: themeStyle
            }}
        >
            {children}
        </ThemeContext.Provider>
    );
};

export const useTheme = (): ThemeContextProps => {
    const context = useContext(ThemeContext);
    if (!context) {
        throw new Error("useTheme must be used within a Auth provider");
    }
    return context;
};
