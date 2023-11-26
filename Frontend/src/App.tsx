import { MenuProvider } from './Infrastructure/Contexts/MenuContext';
import {
  FluentProvider,
  webLightTheme} from "@fluentui/react-components";
import { AuthenticationView } from './Views/Authentication/AuthenticationView';

const App = () => {
  return (
    <>
      <FluentProvider theme={webLightTheme}>
        <MenuProvider>
          <AuthenticationView/>
        </MenuProvider>
      </FluentProvider>
    </>
  );
};

export default App;
