using NUnit.Framework;
using SpecsFor;

namespace LocalDbApi.UnitTests.Instance
{
    public class when_testing_info : SpecsFor<LocalDbApi.Instance>
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