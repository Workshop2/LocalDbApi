using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Should;
using SpecsFor;

namespace LocalDbApi.IntegrationTests.Instance
{
    public class when_testing_create : SpecsFor<LocalDbApi.Instance>
    {
        protected override void InitializeClassUnderTest()
        {
            SUT = new LocalDbApi.Instance();
        }

        protected override void When()
        {
            SUT.Create("IntTest");
        }

        public override void TearDown()
        {
            SUT.Delete("IntTest");
        }

        [Test]
        public void then_instance_should_exist_on_computer()
        {

            System system = new System();
            List<string> instances = system.Info().ToList();

            bool exists = instances.Any(x => x == "IntTest");
            exists.ShouldBeTrue("IntTest should exist on the computer");
        }
    }
}