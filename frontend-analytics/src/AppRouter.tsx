import { Route, Routes } from 'react-router-dom';
import * as Pages from './pages';

const AppRouter = () => (
  <Routes>
    <Route path='/' >
      <Route index element={<Pages.GreetingsPage />} />

      <Route path='heatmap' element={<Pages.HeatmapPage />} />
      <Route path='statistics' element={<Pages.StatisticsPage />} />
      <Route path='predict' element={<Pages.PredictPage />} />
    </Route>
  </Routes>
);

export { AppRouter };
