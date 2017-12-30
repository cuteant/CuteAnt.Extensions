using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;

namespace Microsoft.Extensions.Logging.Internal
{
    /// <summary>AsyncLocalShim</summary>
    /// <typeparam name="T"></typeparam>
    internal sealed class AsyncLocalShim<T>
    {
        private readonly Func<T> _defaultFn;
        private static T GetDefaultValueInternal() => default(T);

        /// <summary>Constructor</summary>
        public AsyncLocalShim()
        {
            _defaultFn = GetDefaultValueInternal;
        }

        /// <summary>Constructor</summary>
        /// <param name="defaultFn"></param>
        public AsyncLocalShim(Func<T> defaultFn)
        {
            if (defaultFn == null) { throw new ArgumentNullException(nameof(defaultFn)); }
            _defaultFn = defaultFn;
        }

        private readonly string _currentKey = $"{nameof(T)}#{Guid.NewGuid().ToString("N")}";

        /// <summary>The current value</summary>
        public T Value
        {
            get
            {
                ObjectHandle objectHandle;
                try
                {
                    objectHandle = CallContext.LogicalGetData(_currentKey) as ObjectHandle;
                }
                catch (NotImplementedException)
                {
                    // Fixed in Mono master: https://github.com/mono/mono/pull/817
                    objectHandle = CallContext.GetData(_currentKey) as ObjectHandle;
                }
                if (objectHandle == null) { return _defaultFn.Invoke(); }
                return (T)objectHandle.Unwrap();
            }
            set
            {
                var objHandle = new ObjectHandle(value);
                try
                {
                    CallContext.LogicalSetData(_currentKey, objHandle);
                }
                catch (NotImplementedException)
                {
                    // Fixed in Mono master: https://github.com/mono/mono/pull/817
                    CallContext.SetData(_currentKey, objHandle);
                }
            }
        }

        /// <summary>clear</summary>
        public void Clear()
        {
            CallContext.FreeNamedDataSlot(_currentKey);
        }
    }
}
