[CmdletBinding(
	SupportsShouldProcess = $false
	,
	ConfirmImpact = "Low"
)]
PARAM (
	[Parameter(Mandatory = $false, Position = 0)]
	[string] $MessageId
	,
	[Parameter(Mandatory = $true, Position = 0)]
	[net.sharedop.Appclusive.Products.Srg.v001.Solution] $Solution
)
# PARAM

[string] $fn = $MyInvocation.MyCommand.Name;
$datBegin = [datetime]::Now;
Log-Debug -fn $fn -msg ("CALL. MsgID [{0}]." -f $MessageId) -fac 1;

Contract-Requires ($Solution.IsValid());

$result = Invoke-RestMethod ("http://srgssr.ch/cmdb/tralala/{0}" -f $Solution.Name);

Log-Info $fn ("Result: {0}" -f $result);

Set-ApcEntityBag -CreateIfNotExist -Nodeid $Node.Id -Name "net.sharedop.Appclusive.Products.Example1.Solution.Name" -Value $result;

return $result;
