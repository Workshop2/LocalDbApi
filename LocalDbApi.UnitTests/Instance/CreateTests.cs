using NUnit.Framework;
using SpecsFor;

namespace LocalDbApi.UnitTests.Instance
{
    public class when_testing_create_instance_command : SpecsFor<LocalDbApi.Instance>
    {
        protected override void When()
        {
            SUT.Info();
            SUT.Create("SimonTest");
        }

        [Test]
        public void test()
        {
            
        }
    }
}