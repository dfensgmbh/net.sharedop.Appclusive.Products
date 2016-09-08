using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using biz.dfch.CS.Appclusive.Public.Configuration;
using biz.dfch.CS.Appclusive.Public.Converters;
using net.sharedop.Appclusive.Products.Example1;

namespace net.sharedop.Appclusive.Products.Srg.v001
{
    [AppclusiveProduct("Solution")]
    //[Icon("picto-folder")]
    public partial class Solution : EntityKindBaseDto
    {
        [EntityBag(Constants.Solution.Name)]
        [Description("The name of the product instance")]
        [Required]
        [ValidatePatternIfNotDefault(Constants.Solution.NamePattern)]
        [StringLength(Constants.Solution.NameMax, MinimumLength = Constants.Solution.NameMin)]
        public virtual string Name { get; set; }
        
        [EntityBag(Constants.Solution.Abbreviation)]
        [Description("Optional description of the product instance")]
        [Required]
        [ValidatePatternIfNotDefault(Constants.Solution.AbbreviationPattern)]
        [StringLength(Constants.Solution.AbbreviationMax, MinimumLength = Constants.Solution.AbbreviationMin)]
        public virtual string Abbreviation { get; set; }

        [EntityBag(Constants.Solution.CmdbId)]
        [Description("Optional description of the product instance")]
        public virtual string InternalId { get; set; }

        private abstract class Status : EntityKindStatusCollection
        {
            public static readonly EntityKindStatus Created;
        }

        public override StateMachine GetStateMachine()
        {
            return new StateMachine
            {
                {() => Status.InitialState, typeof(Initialise), () => Status.Created}
                ,
                {() => Status.Created, typeof(Decommission), () => Status.Decommissioned}
                ,
                {() => Status.Decommissioned, typeof(Finalise), () => Status.FinalState}
            };
        }
    }
}