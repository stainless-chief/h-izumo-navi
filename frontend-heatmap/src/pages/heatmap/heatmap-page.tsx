import { HeatFilterComponent, MapComponent } from "./features/";
import "./heatmap-page.scss";

function HeatmapPage() {

  return (
    <div className="heatmap-container">
      <MapComponent />
      <HeatFilterComponent />
    </div>
  );
}

export { HeatmapPage };
