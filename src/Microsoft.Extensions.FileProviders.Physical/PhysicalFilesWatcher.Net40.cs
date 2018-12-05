// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Microsoft.Extensions.FileProviders.Physical
{
    partial class PhysicalFilesWatcher
    {
#if NET40
        /// <summary>The <c>TaskCreationOptions.DenyChildAttach</c> value, if it exists; otherwise, <c>0</c>.</summary>
        private static readonly TaskCreationOptions _CreationDenyChildAttach;

        static PhysicalFilesWatcher()
        {
            _CreationDenyChildAttach = EnumValue<TaskCreationOptions>("DenyChildAttach") ?? 0;
        }
#endif

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        private static TaskCreationOptions GetCreationOptions(TaskCreationOptions toInclude = TaskCreationOptions.None)
        {
#if !NET40
            return toInclude | TaskCreationOptions.DenyChildAttach;
#else
            return toInclude | _CreationDenyChildAttach;
#endif
        }

        private static T? EnumValue<T>(string name) where T : struct
        {
            try
            {
                return (T)Enum.Parse(typeof(T), name, true);
            }
            catch (ArgumentException)
            {
            }
            catch (OverflowException)
            {
            }
            return null;
        }
    }
}
