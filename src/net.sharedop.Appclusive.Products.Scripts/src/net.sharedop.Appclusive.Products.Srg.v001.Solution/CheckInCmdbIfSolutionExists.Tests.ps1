$here = Split-Path -Parent $MyInvocation.MyCommand.Path
$sut = (Split-Path -Leaf $MyInvocation.MyCommand.Path).Replace(".Tests.", ".")

function Stop-Pester($message = "EMERGENCY: Script cannot continue.")
{
	$msg = $message;
	$e = New-CustomErrorRecord -msg $msg -cat OperationStopped -o $msg;
	$PSCmdlet.ThrowTerminatingError($e);
}

Describe -Tags "Step1.Tests" "Step1.Tests" {

	Mock Export-ModuleMember { return $null; }

	Mock Invoke-RestMethod { return $true; }

	. "$here\$sut"
	
	Context "Step1-Succeeds" {
	
		# Context wide constants
		
		BeforeEach {
			# N/A
		}

		It "Warmup" -Test {
		
			1 | Should Be 1;
		
		}
	
		It "Check-InstallationDirectory" -Test {
		
			Test-Path C:\Logs | Should Be $true;
		}
		
		It "AddingTwoAndTwo-ShouldBeFour" -Test {
		
			$result = Add 2 2
			
			$result | Should Be 4;
		}
		
		It "PowerShellVersion-ShouldBeFive" -Test {
		
			$result = $host.Version.Major;

			$result	-ge 5 | Should Be $true
		
		}
		
		It "TwitterFromDfensGmbh-ContainsDfens" -Test {
		
			$result = GetTwitter https://twitter.com/dfensgmbh;
			
			$result.Contains('abrakadabra') | Should Be $false;
		}
		
		It "DoubleItWithName-ReturnsDoubleNameWithDash" -Test {
		
			$name = "hotzenhausen400";
			
			$result = DoubleIt $name;
			
			$result | Should Be ($name + " - " + $name);
		
		}

		It "DoubleItWithNullName-Throws" -Test {
		
			$name = $null;
			
			{ DoubleIt $name } | Should Throw;
		
		}
		
		It "PatchingARunningVmSucceeds" -Test {
		
			$server = "server1";
			
			$result = Patch-VM $server;
		
			$result | Should Be $true;
		}

		It "PatchingNullVmThrows" -Test {
		
			$server = $null;
			
			{ Patch-VM $server } | Should Throw;
		}
	}


}

#
# Copyright 2016 d-fens GmbH
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
# http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
#
