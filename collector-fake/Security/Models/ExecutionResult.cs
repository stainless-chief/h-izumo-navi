namespace Security.Models
{
    /// <summary> Result of the function execution</summary>
    /// <typeparam name="T">Type of the result</typeparam>
    public sealed class ExecutionResult<T>
    {
        /// <summary> Result </summary>
        public T? Data { get; set; }

        /// <summary> Is execution succeed?</summary>
        public bool IsSucceed { get; set; }

        /// <summary> Execution incident </summary>
        public Incident? Error { get; set; }
    }
}
