using Security.Models;
using Security.Resources;
using System.Data.Common;

namespace Security
{
    public class Supervisor
    {
        public Supervisor()
        {
        }

        public async Task<ExecutionResult<T>> SafeExecuteAsync<T>(Func<Task<T>> func)
        {
            var result = new ExecutionResult<T>();

            try
            {
                result.Data = await func();
                result.IsSucceed = true;
            }
            catch (DbException)
            {
                result.IsSucceed = false;
                result.Error = new Incident
                {
                    Message = ErrorMessages.DatabaseException,
                };
            }
            catch (Exception ee)
            {
                result.IsSucceed = false;
                result.Error = new Incident
                {
                    Message = ee.Message,
                    Detail = ee.InnerException?.Message
                };
            }

            return result;
        }

        public ExecutionResult<T> SafeExecute<T>(Func<T> func)
        {
            var result = new ExecutionResult<T>();

            try
            {
                result.Data = func();
                result.IsSucceed = true;
            }
            catch (DbException)
            {
                result.IsSucceed = false;
                result.Error = new Incident
                {
                    Message = ErrorMessages.DatabaseException,
                };
            }
            catch (Exception ee)
            {
                result.IsSucceed = false;
                result.Error = new Incident
                {
                    Message = ee.Message,
                    Detail = ee.InnerException?.Message
                };
            }

            return result;
        }
    }
}
