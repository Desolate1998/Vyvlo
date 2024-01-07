import React, { useEffect } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { AuthenticationView } from './Views/Authentication/AuthenticationView';
import { useAuth } from './Infrastructure/Contexts/AuthContext';
import { useMenu } from './Infrastructure/Contexts/MenuContext';
import { useTheme } from './Infrastructure/Contexts/ThemeContext';
import Header from './Components/Header/Header';
import Sidebar from './Components/Sidebar/Sidebar';
import { DarkTheme } from './Infrastructure/Themes/darkTheme';
import { LightTheme } from './Infrastructure/Themes/lightTheme';
import { generateRoutes, routes } from './Infrastructure/helpers/Routes';
import { useStore } from './Infrastructure/Contexts/StoreContext';
import { FirstStoreCreation } from './Views/FirstStoreCreation/FirstStoreCreation';

export const AppRouter = () => {
    const { isMenuOpen } = useMenu();
    const { useDarkTheme } = useTheme();
    const { isAuthenticated, tryAutoLogin } = useAuth();
    const { currentStoreId, getStores } = useStore();

    useEffect(() => {
        if (!isAuthenticated) {
            tryAutoLogin()
        }
        getStores()
    }, [])

    if (!isAuthenticated) {
        return (
            <Router>
                <Routes>
                    <Route path="/" Component={AuthenticationView} />
                </Routes>
            </Router>
        );
    } else if (currentStoreId == null) {
        return (
            <Router>
                <Routes>
                    <Route path="/" Component={FirstStoreCreation} />
                </Routes>
            </Router>)
    } else {
        return (
            <Router>
                <div className={`${isMenuOpen ? "container" : "container-close"}`} style={{ backgroundColor: `${useDarkTheme ? DarkTheme.backgroundColor : LightTheme.backgroundColor}` }}>
                    <div className="header">
                        <Header />
                    </div>
                    <div className="MainContent-sidebar">
                        <Sidebar />
                    </div>
                    <div className="main-content" style={{ backgroundColor: `${useDarkTheme ? DarkTheme.backgroundColor : LightTheme.backgroundColor}` }}>
                        <Routes>
                            {generateRoutes(routes)}
                        </Routes>
                    </div>
                </div>
            </Router>
        );

    }

};