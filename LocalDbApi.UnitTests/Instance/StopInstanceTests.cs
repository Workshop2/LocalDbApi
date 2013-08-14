using NUnit.Framework;
using SpecsFor;

namespace LocalDbApi.UnitTests.Instance
{
    [TestFixture]
    public class when_testing_stop_instance : SpecsFor<LocalDbApi.Instance>
    {
        protected override void When()
        {
            SUT.StopInstance("SimonTest");
        }

        [Test]
        public void then_command_line_should_be_called_with_stop_command()
        {
            GetMockFor<IDbCommunication>().Verify(x => x.Execute("stop SimonTest"));
        }
    }
}