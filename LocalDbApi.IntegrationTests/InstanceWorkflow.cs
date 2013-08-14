using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Should;
using SpecsFor;

namespace LocalDbApi.IntegrationTests
{
    [TestFixture]
    public class when_testing_creation_workflow : SpecsFor<Instance>
    {
        private string _instanceName;

        protected override void InitializeClassUnderTest()
        {
            SUT = new Instance();
        }

        protected override void Given()
        {
            Random random = new Random();
            _instanceName = "TestInstance_" + random.Next();
        }

        protected override void When()
        {
            SUT.Create(_instanceName);
        }

        protected override void AfterSpec()
        {
            SUT.Delete(_instanceName);
        }

        [Test]
        public void then_instance_should_exist()
        {
            List<string> instances = SUT.ListInstances().ToList();

            instances.Any(x => x == _instanceName).ShouldBeTrue("Instance should now exist");
        }
    }

    [TestFixture]
    public class when_testing_deletion_workflow : SpecsFor<Instance>
    {
        private string _instanceName;

        protected override void InitializeClassUnderTest()
        {
            SUT = new Instance();
        }

        protected override void Given()
        {
            Random random = new Random();
            _instanceName = "TestInstance_" + random.Next();

            SUT.Create(_instanceName);
        }

        protected override void When()
        {
            SUT.Delete(_instanceName);
        }

        [Test]
        public void then_instance_should_not_exist()
        {
            List<string> instances = SUT.ListInstances().ToList();

            instances.Any(x => x == _instanceName).ShouldBeFalse();
        }
    }
}