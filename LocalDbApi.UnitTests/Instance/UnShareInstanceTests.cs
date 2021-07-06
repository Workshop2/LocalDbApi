using NUnit.Framework;
using SpecsFor;

namespace LocalDbApi.UnitTests.Instance
{
    [TestFixture]
    public class when_testing_unshare_instance : SpecsFor<LocalDbApi.Instance>
    {
        protected override void When()
        {
            SUT.UnShareInstance("simon2");
        }

        [Test]
        public void then_command_line_should_be_called()
        {
            GetMockFor<IDbCommunication>()
                .Verify(x => x.Execute("unshare simon2"));
        }
    }
}