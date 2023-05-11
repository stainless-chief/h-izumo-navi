import './index.scss';
import { AppRouter } from './AppRouter';
import { BrowserRouter } from 'react-router-dom';
import { Header } from './features';
import ReactDOM from 'react-dom/client';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <BrowserRouter>
    <Header/>
    <AppRouter />
  </BrowserRouter>
);
