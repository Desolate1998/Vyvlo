import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './index.css'
import { FluentProvider, teamsLightTheme, webDarkTheme, webLightTheme, teamsDarkTheme } from '@fluentui/react-components';

ReactDOM.createRoot(document.getElementById('root')!).render(
  <FluentProvider theme={teamsLightTheme}>
    <App />
  </FluentProvider>
)
