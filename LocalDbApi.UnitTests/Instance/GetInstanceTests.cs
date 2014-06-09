using System;
using System.Collections.Generic;
using LocalDbApi.Models;
using NUnit.Framework;
using Should;
using SpecsFor;
using SpecsFor.ShouldExtensions;

namespace LocalDbApi.UnitTests.Instance
{
    [TestFixture]
    public class when_testing_get_instance : SpecsFor<LocalDbApi.Instance>
    {
        private Info Result { get; set; }

        protected override void Given()
        {
            List<string> toReturn = new List<string>
            {
                "Name:              v11.0",
                "Version:           11.0.3000.0",
                "SharedName:        MySharedName",
                @"Owner:            MyName\AnotherName",
                "Auto-create:       Yes",
                "State:             Running",
                "Last start time:   " + new DateTime(2013, 08, 07, 06, 05, 04),
                "Instance pipe name:This is my pipe name",
            };

            GetMockFor<IDbCommunication>()
                .Setup(x => x.ExecuteList("info SimonTest"))
                .Returns(toReturn);
        }

        protected override void When()
        {
            Result = SUT.GetInstance("SimonTest");
        }

        [Test]
        public void then_command_line_should_be_called_with_list_command()
        {
            GetMockFor<IDbCommunication>()
                .Verify(x => x.ExecuteList("info SimonTest"));
        }

        [Test]
        public void then_result_should_have_name_populated()
        {
            Result.Name.ShouldEqual("v11.0");
        }

        [Test]
        public void then_result_should_have_version_populated()
        {
            Version expected = new Version(11, 0, 3000, 0);
            Result.Version.ShouldLookLike(expected);
        }

        [Test]
        public void then_result_should_have_shared_name_populated()
        {
            Result.SharedName.ShouldEqual("MySharedName");
        }

        [Test]
        public void then_result_should_have_owner_populated()
        {
            Result.Owner.ShouldEqual(@"MyName\AnotherName");
        }

        [Test]
        public void then_result_should_have_auto_create_populated()
        {
            Result.AutoCreate.ShouldBeTrue();
        }

        [Test]
        public void then_result_should_have_state_populated()
        {
            Result.State.ShouldLookLike(State.Running);
        }

        [Test]
        public void then_result_should_have_last_started_time_populated()
        {
            DateTime expected = new DateTime(2013, 08, 07, 06, 05, 04);
            Result.LastStartTime.ShouldLookLike(expected);
        }

        [Test]
        public void then_result_should_have_instance_pipe_name_populated()
        {
            Result.InstancePipeName.ShouldLookLike("This is my pipe name");
        }
    }
}