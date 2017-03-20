﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using CuteAnt.Extensions.JsonPatch.Exceptions;

namespace CuteAnt.Extensions.JsonPatch.Internal
{
    internal static class ErrorReporter
    {
        public static readonly Action<JsonPatchError> Default = (error) =>
        {
            throw new JsonPatchException(error);
        };
    }
}
