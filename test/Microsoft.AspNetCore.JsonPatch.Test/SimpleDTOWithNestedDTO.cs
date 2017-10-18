﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Microsoft.AspNetCore.JsonPatch
{
    public class SimpleDTOWithNestedDTO
    {
        public int IntegerValue { get; set; }

        public NestedDTO NestedDTO { get; set; }

        public SimpleDTO SimpleDTO { get; set; }

        public InheritedDTO InheritedDTO { get; set; }

        public List<SimpleDTO> SimpleDTOList { get; set; }

        public IList<SimpleDTO> SimpleDTOIList { get; set; }

        public SimpleDTOWithNestedDTO()
        {
            this.NestedDTO = new NestedDTO();
            this.SimpleDTO = new SimpleDTO();
            this.InheritedDTO = new InheritedDTO();
            this.SimpleDTOList = new List<SimpleDTO>();
        }
    }
}