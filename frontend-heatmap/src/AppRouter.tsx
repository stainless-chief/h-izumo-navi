import React, { lazy } from "react";
import { Navigate, Route, Routes } from "react-router-dom";
import * as Pages from "./pages";
import App from './App';

const AppRouter = () => (
  <Routes>
    <Route path="/" >
      {/* <Route path="*" element={<Pages.ErrorNotFoundPage />} /> */}

      <Route index element={<App />} />

      <Route path="map" element={<Pages.HeatmapPage />} />

    </Route>
  </Routes>
);

export { AppRouter };
