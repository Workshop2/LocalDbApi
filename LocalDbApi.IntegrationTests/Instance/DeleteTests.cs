using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Should;
using SpecsFor;

namespace LocalDbApi.IntegrationTests.Instance
{
    public class when_testing_delete : SpecsFor<LocalDbApi.Instance>
    {
        protected override void InitializeClassUnderTest()
        {
            SUT = new LocalDbApi.Instance();
        }

        protected override void Given()
        {
            SUT.Create("IntDeleteTest");

            System system = new System();
            List<string> instances = system.Info().ToList();

            bool exists = instances.Any(x => x == "IntDeleteTest");
            exists.ShouldBeTrue("IntDeleteTest should exist on the computer");
        }

        protected override void When()
        {

            SUT.Delete("IntDeleteTest");
        }

        [Test]
        public void then_instance_should_not_exist_on_computer()
        {
            System system = new System();
            List<string> instances = system.Info().ToList();

            bool exists = instances.Any(x => x == "IntDeleteTest");
            exists.ShouldBeFalse("IntDeleteTest should not longer exist on the computer");
        }
    }
}