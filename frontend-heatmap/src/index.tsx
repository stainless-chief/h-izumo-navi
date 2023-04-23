import React from 'react';
import ReactDOM from 'react-dom/client';
import { Header } from "./features";
import { BrowserRouter } from "react-router-dom";
import './index.scss';
import { AppRouter } from "./AppRouter";

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <BrowserRouter>
    <Header/>
    <AppRouter />
  </BrowserRouter>
);
