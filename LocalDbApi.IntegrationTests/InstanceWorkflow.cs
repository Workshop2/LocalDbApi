using System;
using System.Collections.Generic;
using System.Linq;
using LocalDbApi.Models;
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

    [TestFixture]
    public class when_testing_get_instance_workflow : SpecsFor<Instance>
    {
        private string _instanceName;
        private Info Result { get; set; }

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
            Result = SUT.GetInstance(_instanceName);
        }

        protected override void AfterSpec()
        {
            SUT.Delete(_instanceName);
        }

        [Test]
        public void then_instance_should_exist()
        {
            Result.ShouldNotBeNull();
        }

        [Test]
        public void then_name_should_be_correct()
        {
            Result.Name.ShouldEqual(_instanceName);
        }

        [Test]
        public void then_state_should_be_started()
        {
            Result.State.ShouldEqual(State.Running);
        }

        [Test]
        public void then_last_start_time_should_be_within_last_minute()
        {
            DateTime expected = DateTime.Now.AddMinutes(-1);
            Result.LastStartTime.ShouldBeGreaterThanOrEqualTo(expected);
        }

        [Test]
        public void then_version_should_be_greater_than_11()
        {
            Version expected = new Version(11, 0, 0, 0);
            Result.Version.ShouldBeGreaterThan(expected);
        }
    }
}