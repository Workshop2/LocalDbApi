using NUnit.Framework;
using SpecsFor;

namespace LocalDbApi.UnitTests.System
{
    public class when_testing_info : SpecsFor<LocalDbApi.System>
    {
        protected override void When()
        {
            SUT.Info();
        }

        [Test]
        public void then_command_line_should_be_called_with_info_command()
        {
            GetMockFor<ICommandLine>().Verify(x => x.ExecuteList("info"));
        }
    }
}