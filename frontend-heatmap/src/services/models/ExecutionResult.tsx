import { Incident } from "./Incident";

class ExecutionResult<T> {
  isSucceed: boolean;
  data: T;
  error: Incident;
}

export { ExecutionResult };
