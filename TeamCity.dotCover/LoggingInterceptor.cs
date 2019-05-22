namespace TeamCity.dotCover
{
    using System.Collections;
    using System.Linq;
    using Castle.DynamicProxy;

    // ReSharper disable once ClassNeverInstantiated.Global
    internal class LoggingInterceptor: StandardInterceptor
    {
        private readonly ITrace _trace;

        public LoggingInterceptor(ITrace trace) => _trace = trace;

        protected override void PostProceed(IInvocation invocation)
        {
            base.PostProceed(invocation);
            var args = string.Join(", ", invocation.Arguments.Select(GetText));
            _trace.WriteLine($"{invocation.TargetType.Name}.{invocation.Method.Name}({args}){GetReturnValue(invocation)}");
        }

        private static string GetReturnValue(IInvocation invocation) => 
            invocation.ReturnValue == default ? string.Empty : $" returns {GetText(invocation.ReturnValue)}";

        private static string GetText(object val)
        {
            switch (val)
            {
                case default(object):
                    return "null";

                case string str:
                    return $"\"{str}\"";

                case IEnumerable enumerable:
                    return $"[{string.Join(", ", enumerable.Cast<object>().Select(GetText))}]";

                default:
                    return val.ToString();
            }
        }
    }
}
