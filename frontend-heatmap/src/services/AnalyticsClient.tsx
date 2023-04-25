import * as axios from "axios";
import { ExecutionResult, AnalyticsSource  } from "./";
import { Utils } from "./Utils";


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

  public static async getSources() {
    return await this.init().get<ExecutionResult<AnalyticsSource[]>>("/source/all")
      .then(response => {
        return response.data;
      })
      .catch((error: axios.AxiosError) => {
        return Utils.create<AnalyticsSource[]>(error);
      });
  };
}

export { AnalyticsClient };
