import * as axios from "axios";
import { ExecutionResult, AnalyticsSource, AnalyticsHeatZone, AnalyticsHeatZoneCollection, StatisticItem  } from "./";
import { Utils } from "./Utils";
import { Feature, FeatureCollection, GeoJsonProperties, Geometry, Position } from "geojson";
import { number } from "yargs";


class AnalyticsClient {
  private static init() {
    return axios.default.create({
      baseURL: window._env_.REACT_APP_API_ANALYTICS,
      timeout: 31000,
      headers: {
        Accept: "application/json"
      }
    });
  };

  public static async getStatistics() {
    return await this.init().get<ExecutionResult<StatisticItem[]>>("/statistics")
      .then(response => {
        return response.data;
      })
      .catch((error: axios.AxiosError) => {
        return Utils.create<StatisticItem[]>(error);
      });
  };

  public static async getSources() {
    return await this.init().get<ExecutionResult<AnalyticsSource[]>>("/source/all")
      .then(response => {
        return response.data;
      })
      .catch((error: axios.AxiosError) => {
        return Utils.create<AnalyticsSource[]>(error);
      });
  };

  public static async getHeatMap(codes: string[]) {
    return await this.init()
    .post<ExecutionResult<AnalyticsHeatZone[]>>("/heatzone", codes)
    .then(response => {
        let tmp: AnalyticsHeatZoneCollection;
        tmp = new AnalyticsHeatZoneCollection();
        tmp.type = 'FeatureCollection';

        tmp.features = response.data.data.map(function (value: AnalyticsHeatZone)
        {
          return {
            type: 'Feature',
            properties:
            {
              temperature: value.temperature,
              hitStatistics: value.hitStatistics,
            },
            geometry:
            { 
              type: "Polygon",
              coordinates:[
                value.coordinates.map(zone => [zone.x, zone.y])
              ],
            }
          }
        });
        return tmp;
    })
    // .catch((error: axios.AxiosError) => {
    //     return Utils.create<AnalyticsHeatZone[]>(error);
    // });
  };

}

export { AnalyticsClient };
