import { AnalyticsSource } from "./AnalyticsSource";
import { ZoneCoordinates } from "./ZoneCoordinates";

class StatisticItem {
  placeName: string;
  temperature: number;
  coordinates: ZoneCoordinates[];
  sources: AnalyticsSource[];
  characteristics: string[];
}

export { StatisticItem };
