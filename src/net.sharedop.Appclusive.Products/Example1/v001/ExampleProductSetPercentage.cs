﻿/**
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

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using biz.dfch.CS.Appclusive.Public.Configuration;
using biz.dfch.CS.Appclusive.Public.Converters;

namespace net.sharedop.Appclusive.Products.Example1.v001
{
    public partial class ExampleProduct
    {
        // this state transition is defined via schema form and uses the default naming convention, 
        // which is: ExampleProductSetPercentage
        [UserInterface(biz.dfch.CS.Appclusive.Public.Constants.Configuration.UserInterface.UserInterfaceTypeEnum.AngularSchemaForm)]
        public class SetPercentage : EntityKindStateTransitionBaseDto
        {
            [EntityBag(Constants.ExampleProduct.Percentage)]
            [Range(Constants.ExampleProduct.PercentageMin, Constants.ExampleProduct.PercentageMax)]
            [DefaultValue(Constants.ExampleProduct.PercentageDefault)]
            [Unit("%")]
            public virtual double Percentage { get; set; }
        }
    }
}
