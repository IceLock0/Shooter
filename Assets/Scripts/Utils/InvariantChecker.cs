using System;

namespace Utils
{
    public static class InvariantChecker
    {
        public static void CheckObjectInvariant(params object[] args)
        {
            foreach (var arg in args)
            {
                if (arg == null)
                    throw new NullReferenceException();
            }
        }
    }
}