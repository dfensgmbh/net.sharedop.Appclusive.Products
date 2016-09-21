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

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using biz.dfch.CS.Appclusive.Public.Configuration;
using Configuration = biz.dfch.CS.Appclusive.Public.Constants.Configuration;
using biz.dfch.CS.Appclusive.Public.Converters;

namespace net.sharedop.Appclusive.Products.Example1.v001
{
    // this annotation indicates that this is also a product (and not only an EntityKind)
    [AppclusiveProduct("Example Product")]
    // specifies the icon to use for visualing the EntityKind
    [Icon("windows")]
    // this description will be applied to EntityKind.Description
    [Description("InternalWorkflow")]
    // uses Python as the default implementation for the product logic
    [ExecutionType(Configuration.ExecutionType.ExecutionTypeEnum.Python)]
    public partial class ExampleProduct : EntityKindBaseDto
    {
        [EntityBag(Constants.ExampleProduct.Name)]
        [Description("The name of the product instance")]
        [Required]
        public virtual string Name { get; set; }
        
        [EntityBag(Constants.ExampleProduct.Description)]
        [Description("Optional description of the product instance")]
        public virtual string Description { get; set; }

        [EntityBag(Constants.ExampleProduct.Percentage)]
        [Description("A percentage you can configure for this product instance")]
        [Range(Constants.ExampleProduct.PercentageMin, Constants.ExampleProduct.PercentageMax)]
        [DefaultValue(Constants.ExampleProduct.PercentageDefault)]
        public virtual double Percentage { get; set; }

        [EntityBag(Constants.ExampleProduct.Id)]
        [Description("A unique identifier of this product instance")]
        [Required]
        [DefaultValue("00000000-0000-0000-0000-000000000000")]
        [Guid]
        public virtual string Id { get; set; }

        [EntityBag(Constants.ExampleProduct.Owner)]
        [Description("Mail address of the owner of this product instance")]
        [Required]
        [EmailAddress]
        public virtual string Owner { get; set; }

        // here we reference an EntityBag of a foreign product
        [EntityBag("net.sharedop.cms.tralala.SomeParameter")]
        [Description("Mail address of the owner of this product instance")]
        [Range(0, 42)]
        [Required]
        // this annotatoin requires that the value of this property may only have increments of 0.652
        [Increment(0.652)]
        public virtual double MagicNumber { get; set; }

        private abstract class Status : EntityKindStatusCollection
        {
            public static readonly EntityKindStatus Active;
            public static readonly EntityKindStatus Inactive;
        }

        public override StateMachine GetStateMachine()
        {
            return new StateMachine
            {
                {() => Status.InitialState, typeof(Initialise), () => Status.Active}
                ,
                {() => Status.Active, typeof(Deactivate), () => Status.Inactive}
                ,
                {() => Status.Inactive, typeof(Activate), () => Status.Active}
                ,
                {() => Status.Inactive, typeof(SetPercentage), () => Status.Inactive}
                ,
                {() => Status.Inactive, typeof(Deactivate), () => Status.Decommissioned}
                ,
                {() => Status.Decommissioned, typeof(Finalise), () => Status.FinalState}
            };
        }
    }
}
