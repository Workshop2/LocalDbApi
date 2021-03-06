﻿using NUnit.Framework;
using SpecsFor;

namespace LocalDbApi.UnitTests.Instance
{
    [TestFixture]
    public class when_testing_create : SpecsFor<LocalDbApi.Instance>
    {
        protected override void When()
        {
            SUT.Create("SimonTest");
        }

        [Test]
        public void then_command_line_should_be_called_with_create_command()
        {
            GetMockFor<IDbCommunication>().Verify(x => x.Execute("create SimonTest -s"));
        }
    }
}