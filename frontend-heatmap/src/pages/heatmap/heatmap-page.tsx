import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { HeatFilterComponent } from "./features/";
import "./heatmap-page.scss";

function HeatmapPage() {

  return (
    <div>
      <div>map</div>
      <HeatFilterComponent />
    </div>
  );
}

export { HeatmapPage };
