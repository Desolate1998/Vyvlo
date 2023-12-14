import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './index.css'
import { FluentProvider, teamsLightTheme, webDarkTheme, webLightTheme, teamsDarkTheme } from '@fluentui/react-components';
import { ThemeProvider } from './Infrastructure/Contexts/ThemeContext.tsx';

ReactDOM.createRoot(document.getElementById('root')!).render(
  <ThemeProvider>
      <App />
  </ThemeProvider>
)
