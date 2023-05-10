import { BBox, Feature, FeatureCollection, GeoJsonProperties, Geometry } from "geojson";
import { ZoneCoordinates } from "./ZoneCoordinates";

class AnalyticsHeatZone {
  temperature: number;
  hitStatistics: Record<string, number>;
  coordinates: ZoneCoordinates[];
}

class AnalyticsHeatZoneCollection implements FeatureCollection<Geometry, GeoJsonProperties> {
  type: "FeatureCollection";
  features: Feature<Geometry, GeoJsonProperties>[];
  bbox?: BBox | undefined;
}

export { AnalyticsHeatZone };
export { AnalyticsHeatZoneCollection };