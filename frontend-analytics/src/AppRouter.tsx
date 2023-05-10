import { Route, Routes } from "react-router-dom";
import * as Pages from "./pages";

const AppRouter = () => (
  <Routes>
    <Route path="/" >
      {/* <Route path="*" element={<Pages.ErrorNotFoundPage />} /> */}

      <Route index element={<Pages.GreetingsPage />} />

      <Route path="heatmap" element={<Pages.HeatmapPage />} />
      <Route path="statistics" element={<Pages.StatisticsPage />} />

    </Route>
  </Routes>
);

export { AppRouter };
