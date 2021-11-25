using System;
using System.Diagnostics;
using Astrolabe.Exceptions.Verifications;

;

namespace Astrolabe.Exceptions
{
    public static class Cather
    {
        public static void TryInvoke<TException, TArg>(this Action<TArg> action, TArg arg) where TException : Exception
        {
            try
            {
                Argument.NotNull(action, nameof(action));
                action.Invoke(arg);
            }
            catch (TException e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}