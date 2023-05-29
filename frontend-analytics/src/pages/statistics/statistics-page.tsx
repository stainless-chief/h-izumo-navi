import 'mapbox-gl/dist/mapbox-gl.css';
import './statistics-page.scss';
import { AnalyticsClient, AnalyticsHeatZoneCollection, Incident, StatisticItem } from '../../services';
import { FeatureCollection, GeoJsonProperties, Geometry } from 'geojson';
import { StatisticsComponent } from './features/full-statistics/full-statistics-component';
import { useCallback, useEffect, useRef, useState } from "react";
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

function StatisticsPage() {
  const [heatZones, setHeatZones] = useState<FeatureCollection<Geometry, GeoJsonProperties>>();
  const [hoverInfo, setHoverInfo] = useState(null);
  const [incident, setIncident] = useState<Incident | null>(null);
  const [statistics, setStatistics] = useState<StatisticItem[] | null>(null);
  const { t } = useTranslation();
  const mapRef = useRef(null);

  useEffect(() => {
    const fetchData = async() => {
      const result = await AnalyticsClient.getStatistics();
      if (result.isSucceed) {
        setStatistics(result.data);

        const zones = new AnalyticsHeatZoneCollection();
        zones.type = 'FeatureCollection';

        zones.features = result.data.map(function (value: StatisticItem) {
          return {
            type: 'Feature',
            properties: {
              temperature: value.temperature,
              characteristics: value.characteristics,
              hitStatistics: value.sources,
            },
            geometry: { 
              type: "Polygon",
              coordinates:[
                value.coordinates.map(zone => [zone.x, zone.y])
              ],
            }
          }
        });
        setHeatZones(zones);
      } else {
        setIncident(result.error);
      }};

    setIncident(null);
    fetchData();
  }, []);

  async function moveToLocation(latitude:number, longitude: number) {
    mapRef.current?.flyTo({ center: [latitude,longitude ] });
  }

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

  if (statistics == null) {
    return <div>Loading</div>;
  } else {
    return (
      <div className="heatmap-container">
        <Map
          ref={mapRef} 
          initialViewState={{
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
            { hoverInfo
            && (
            <Popup
              latitude={hoverInfo.lngLat.lat}
              longitude={hoverInfo.lngLat.lng}
              closeButton={false}>
              {
                (
                  <div>
                    <b>{t("HeatMapTooltip.Temperature")} : </b>
                    {hoverInfo.hoveredFeature.properties.temperature} <br/>
                    {hoverInfo.hoveredFeature.properties.characteristics}
                    {/* TODO: make tooltip pretty  */}
                    {/* {hoverInfo.hoveredFeature.properties.hitStatistics} */}
                  </div>
                )
              }
            </Popup>)}
        </Map>
      <StatisticsComponent statistics={statistics!} 
                           moveToLocation={moveToLocation!} />
    </div>
    );
  }
}

export { StatisticsPage };
