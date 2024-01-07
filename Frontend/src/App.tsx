import { MenuProvider } from './Infrastructure/Contexts/MenuContext';
import {
  FluentProvider,
  webDarkTheme,
  webLightTheme
} from "@fluentui/react-components";
import { initializeIcons } from '@fluentui/font-icons-mdl2';
import { ReactNotifications } from 'react-notifications-component'
import { AppRouter } from './AppRouter';
import 'react-notifications-component/dist/theme.css'
import { AuthProvider } from './Infrastructure/Contexts/AuthContext';
import { useTheme } from './Infrastructure/Contexts/ThemeContext';
import { StoreProvider } from './Infrastructure/Contexts/StoreContext';

initializeIcons();
const App = () => {
  const { useDarkTheme } = useTheme()
  return (
    <AuthProvider >
      <ReactNotifications />
      <FluentProvider theme={useDarkTheme ? webDarkTheme : webLightTheme}>
        <StoreProvider>
          <MenuProvider>
            <AppRouter />
          </MenuProvider>
        </StoreProvider>
      </FluentProvider>
    </AuthProvider>
  );
};

export default App;
