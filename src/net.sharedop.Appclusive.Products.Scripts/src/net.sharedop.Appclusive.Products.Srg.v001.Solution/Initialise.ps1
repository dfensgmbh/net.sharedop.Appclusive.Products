#Requires -Modules @{ ModuleName = 'biz.dfch.PS.Appclusive.Client'; ModuleVersion = "4.3.0" }

[CmdletBinding(
	SupportsShouldProcess = $false
	,
	ConfirmImpact = "Low"
)]
PARAM (
	[Parameter(Mandatory = $false, Position = 0)]
	[string] $MessageId
	,
	[Parameter(Mandatory = $false, Position = 1)]
	[biz.dfch.CS.Appclusive.Api.Core.Job] $Job
	,
	[Parameter(Mandatory = $false, Position = 2)]
	[biz.dfch.CS.Appclusive.Api.Core.Node] $Node
	,
	[Parameter(Mandatory = $false, Position = 3)]
	[biz.dfch.CS.Appclusive.Api.Core.EntityKind] $EntityKind
	,
	[Parameter(Mandatory = $false, Position = 4)]
	$WorkerContext
)
# PARAM

BEGIN 
{
	trap { Log-Exception $_; break; }
	
	# Default variables
	[string] $fn = $MyInvocation.MyCommand.Name;
	$datBegin = [datetime]::Now;
	Log-Debug -fn $fn -msg ("CALL. MsgID [{0}]. JobID [{1}]. NodeID [{2}]." -f $MessageId, $Job.Id, $Node.Id) -fac 1;
	Log-BreadCrumb $fn ("CALL.");

	Contract-Requires (!!$Job);
	Contract-Requires (!!$Node);
	Contract-Requires (!!$EntityKind);
	Contract-Requires (!!$WorkerContext);
}
# END

PROCESS 
{
	trap { Log-Exception $_; break; }

	# Default test variable for checking function response codes.
	[Boolean] $fReturn = $false;
	# Return values are always and only returned via OutputParameter.
	$OutputParameter = $null;
	
	#	Custom Code
	#
	#
	#
	#

	$fReturn = $true;
}

END 
{
	$datEnd = [datetime]::Now;
	Log-Debug -fn $fn -msg ("RET. fReturn: [{0}]. Execution time: [{1}]ms. Started: [{2}]." -f $fReturn, ($datEnd - $datBegin).TotalMilliseconds, $datBegin.ToString('yyyy-MM-dd HH:mm:ss.fffzzz')) -fac 2;
	Log-BreadCrumb $fn ('RET: [{0}]' -f $fReturn);
	
	# Return values are always and only returned via OutputParameter.
	return $OutputParameter;
} 
