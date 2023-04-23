import { Route, Routes } from "react-router-dom";
import * as Pages from "./pages";

const AppRouter = () => (
  <Routes>
    <Route path="/" >
      {/* <Route path="*" element={<Pages.ErrorNotFoundPage />} /> */}

      <Route index element={<Pages.GreetingsPage />} />

      <Route path="map" element={<Pages.HeatmapPage />} />

    </Route>
  </Routes>
);

export { AppRouter };
