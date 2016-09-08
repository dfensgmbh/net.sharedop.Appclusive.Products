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

// ReSharper disable InconsistentNaming

namespace net.sharedop.Appclusive.Products.Srg
{
    public class Constants
    {
        public class Solution
        {
            public const string ProductPrefix = "net.sharedop.Appclusive.Products.Example1.Solution.";

            public const string Name = ProductPrefix + "Name";
            public const string NamePattern = "\\w+";
            public const int NameMin = 4;
            public const int NameMax = 256;

            public const string Abbreviation = ProductPrefix + "Abbreviation";
            public const string AbbreviationPattern = "[A-Z0-9]+";
            public const int AbbreviationMin = 4;
            public const int AbbreviationMax = 4;

            public const string CmdbId = ProductPrefix + "CmdbId";
        }
    }
}
