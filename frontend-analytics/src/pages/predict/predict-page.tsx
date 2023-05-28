import 'mapbox-gl/dist/mapbox-gl.css';
import "./predict-page.scss";
import { AnalyticsClient, AnalyticsSource, Incident } from "../../services";
import { FeatureCollection, GeoJsonProperties, Geometry } from "geojson";
import { PredictFilterComponent } from "./features";
import { useCallback, useEffect, useState } from "react";
import { useTranslation } from 'react-i18next';
import Map, { Layer, Source, FillLayer, Popup } from 'react-map-gl';
import mapboxgl from 'mapbox-gl';

// The following is required to stop "npm build" from transpiling mapbox code.
// notice the exclamation point in the import.
// @ts-ignore
// eslint-disable-next-line import/no-webpack-loader-syntax, import/no-unresolved
mapboxgl.workerClass = require('worker-loader!mapbox-gl/dist/mapbox-gl-csp-worker').default;

// For more information on data-driven styles, see https://www.mapbox.com/help/gl-dds-ref/
export const dataLayer: FillLayer = {
  id: 'data',
  type: 'fill',
  paint: {
    'fill-color': {
      property: 'temperature',
      stops: [
        [0, '#808080'],
        [10, '#00ffe4'],
        [20, '#33f3b9'],
        [30, '#5ae68b'],
        [40, '#7ad65b'],
        [50, '#95c524'],
        [60, '#afb100'],
        [70, '#c79a00'],
        [80, '#dd7d00'],
        [90, '#f05700'],
        [100, '#ff0000'],
      ]
    },
    'fill-opacity': 0.5
  }
};

function PredictPage() {
  const [analyticsSources, setAnalyticsSources] = useState<AnalyticsSource[] | null>(null);
  const [heatZones, setHeatZones] = useState<FeatureCollection<Geometry, GeoJsonProperties>>();
  const [hoverInfo, setHoverInfo] = useState(null);
  const [incident, setIncident] = useState<Incident | null>(null);
  const { t } = useTranslation();

  async function reloadHeatZone(code: string) 
  {
    const result = await AnalyticsClient.getPredictionMap();
    setHeatZones(result);
  }

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

  const onHover = useCallback(event => {
    const {
      features,
      lngLat,
    } = event;
    const hoveredFeature = features[0];

    if (hoveredFeature) {
      setHoverInfo({hoveredFeature, lngLat});
    }
  }, []);


  if (incident) {
    return <div>{incident.message}</div>;
  }

  if (analyticsSources == null) {
    return <div>Loading</div>;
  } else {
    return (
      <div className="predict-container">
        <Map initialViewState={{
          latitude: 35.383822,
          longitude: 132.767306,
          zoom: 12 }}
          style={{height: 600}}
          mapStyle="mapbox://styles/mapbox/streets-v12"
          interactiveLayerIds={['data']}
          mapboxAccessToken={window._env_.REACT_APP_MAPBOX_API_KEY}
          onMouseMove={onHover}>
            <Source type="geojson" data={heatZones}>
              <Layer {...dataLayer} />
            </Source>
            {hoverInfo
            && hoverInfo.hoveredFeature.properties.temperature > 0
            && (
            <Popup latitude={hoverInfo.lngLat.lat} longitude={hoverInfo.lngLat.lng}
                   closeButton={false}>
                    {(
                    <div>
                      <b>{t("HeatMapTooltip.Temperature")}</b>
                      {hoverInfo.hoveredFeature.properties.temperature} <br/>
                      {/* TODO: make tooltip pretty  */}
                      { hoverInfo.hoveredFeature.properties.hitStatistics }
                    </div>
                    )}
            </Popup>)}
        </Map>
      <PredictFilterComponent reloadHeatZone={reloadHeatZone}/>
    </div>
    );
  }
}

export { PredictPage };
