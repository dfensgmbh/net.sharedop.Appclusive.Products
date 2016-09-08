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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using net.sharedop.Appclusive.Products.Srg.v001;

namespace net.sharedop.Appclusive.Products.Tests.Srg.v001
{
    [TestClass]
    public class SolutionTest
    {
        [TestMethod]
        public void IsValidStateMachine()
        {
            // Arrange, Act
            var sut = new Solution().GetStateMachine();

            var result = sut.IsValid();
            var errorMessages = sut.GetErrorMessages();

            if (!result)
            {
                foreach (var errorMessage in errorMessages)
                {
                    var message = string.Format("Invalid StateMachine '{0}'", errorMessage);
                    System.Diagnostics.Trace.WriteLine(message);
                }
            }

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DefaultInstantiationValidationSucceeds()
        {
            var sut = new Solution();
            sut.Name = "abcd";
            sut.Abbreviation = "ABCD";

            var result = sut.IsValid();
            var errorMessages = sut.GetErrorMessages();

            if (!result)
            {
                foreach (var errorMessage in errorMessages)
                {
                    var message = string.Format("Invalid StateMachine '{0}'", errorMessage);
                    System.Diagnostics.Trace.WriteLine(message);
                }
            }

            // Assert
            Assert.IsTrue(result);
        }
    }
}
