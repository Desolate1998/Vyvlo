import React, { createContext, useState, useContext } from 'react';
import { User } from '../Types/User';

interface AuthContextData {
    isAuthenticated: boolean;
    login: (data: User) => void;
    logout: () => void;
    user: User | undefined;
    tryAutoLogin: () => void;
}

interface AuthProviderProps {
    children: React.ReactNode;

}

const AuthContext = createContext<AuthContextData | undefined>(undefined);

export const AuthProvider: React.FC<AuthProviderProps> = ({ children }) => {
    const [isAuthenticated, setIsAuthenticated] = useState(false);
    const [user, setUser] = useState<User | undefined>(undefined);

    const tryAutoLogin = () => {
        const user = localStorage.getItem('user');
        if (user) {
            setIsAuthenticated(true);
            setUser(JSON.parse(user))
            console.log('user', user)
        }
    }

    const login = (data: User) => {
        setIsAuthenticated(true);
        setUser(data);
        localStorage.setItem('user', JSON.stringify(data));
    };

    const logout = () => {
        setIsAuthenticated(false);
        setUser(undefined);
        localStorage.removeItem('user');
    };

    return (
        <AuthContext.Provider value={{ isAuthenticated, login, logout, user, tryAutoLogin }}>
            {children}
        </AuthContext.Provider>
    );
};

export function useAuth() {
    const context = useContext(AuthContext);
    if (!context) {
        throw new Error('useAuth must be used within an AuthProvider');
    }
    return context;
}