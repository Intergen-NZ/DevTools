public static class AsyncHelpers
{
      /// <summary>
      /// Execute an async method which has a void return value synchronously
      /// </summary>
      /// <param name="method">Task<T/> method to execute</param>
      public static void RunSync(Func<Task> method)
      {
          Argument.CheckIfNull(method, nameof(method));

          Task.WaitAll(method());
      }

      /// <summary>
      /// Execute an async method which has a T return type synchronously
      /// </summary>
      /// <typeparam name="T">Return type</typeparam>
      /// <param name="method">The async function to execute.</param>
      public static T RunSync<T>(Func<Task<T>> func)
      {
          Argument.CheckIfNull(func, nameof(func));

          T result = default(T);
          RunSync(async () => { result = await func(); });
          return result;
      }
}
