import { useEffect, useState } from "react";
import { HeatFilterComponent, MapComponent } from "./features/";
import "./heatmap-page.scss";
import { AnalyticsClient, AnalyticsSource, Incident } from "../../services";

function HeatmapPage() {
  const [analyticsSources, setAnalyticsSources] = useState<AnalyticsSource[] | null>(null);
  const [incident, setIncident] = useState<Incident | null>(null);
  
  useEffect(() => {
    const fetchData = async() => {
      const result = await AnalyticsClient.getSources();
      if (result.isSucceed) {
        setAnalyticsSources(result.data);
      } else {
        setIncident(result.error);
      }
    };

    setIncident(null);
    fetchData();
  }, []);

  if (incident) {
    return <div>error</div>;
  }

  if (analyticsSources == null) {
    return <div>load</div>;
  } else {
    return (
      <div className="heatmap-container">
      <MapComponent />
      <HeatFilterComponent analyticsSources={analyticsSources!} />
    </div>
    );
  }
}

export { HeatmapPage };
