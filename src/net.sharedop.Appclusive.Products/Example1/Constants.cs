/**
 * Copyright 2016 d-fens GmbH
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable InconsistentNaming

namespace net.sharedop.Appclusive.Products.Example1
{
    public class Constants
    {
        public class ExampleProduct
        {
            public const string ProductPrefix = "net.sharedop.Appclusive.Products.Example1.ExampleProduct.";

            public const string Name = ProductPrefix + "Name";
            public const string Description = ProductPrefix + "Description";
            public const string Percentage = ProductPrefix + "Percentage";
            public const double PercentageMin = 0;
            public const double PercentageMax = 1;
            public const double PercentageDefault = 0.5;
            public const string Id = ProductPrefix + "Id";
            public const string Owner = ProductPrefix + "Owner";
        }

    }
}
