import * as axios from "axios";
import { ExecutionResult } from "./models/ExecutionResult";
import { Incident } from "./models/Incident";

class Utils {
  public static create<T>(error: axios.AxiosError) {
    console.log(error);

    const localResult = new ExecutionResult<T>();
    localResult.isSucceed = false;
    localResult.error = new Incident(error.message);

    return localResult;
  }
}

export { Utils };
