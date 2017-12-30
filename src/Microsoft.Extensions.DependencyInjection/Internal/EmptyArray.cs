//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// System.ServiceModel\System\ServiceModel\EmptyArray.cs
//-----------------------------------------------------------------------------

namespace Microsoft.Extensions.Internal
{
    public sealed class EmptyArray<T>
    {
        public static readonly T[] Instance;

        static EmptyArray()
        {
            Instance = new T[0];
        }
    }

    public sealed class EmptyArray
    {
        public static T[] Empty<T>() => EmptyArray<T>.Instance;
    }
}
