using NUnit.Framework;
using SpecsFor;

namespace LocalDbApi.UnitTests.Instance
{
    public class when_testing_delete : SpecsFor<LocalDbApi.Instance>
    {
        protected override void When()
        {
            SUT.Delete("SimonTest");
        }

        [Test]
        public void then_command_line_should_be_called_with_delete_command()
        {
            GetMockFor<ICommandLine>().Verify(x => x.Execute("delete SimonTest"));
        }
    }
}