import { AnalyticsSource } from "./AnalyticsSource";
import { ZoneCoordinates } from "./ZoneCoordinates";

class StatisticItem {
  placeName: string;
  temperature: number;
  placeCoordinates: ZoneCoordinates[];
  sources: AnalyticsSource[];
}

export { StatisticItem };
