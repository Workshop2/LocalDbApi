using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SpecsFor;
using SpecsFor.ShouldExtensions;

namespace LocalDbApi.UnitTests.Instance
{
    [TestFixture]
    public class when_testing_list : SpecsFor<LocalDbApi.Instance>
    {
        protected IEnumerable<string> Result { get; set; }

        protected override void Given()
        {
            GetMockFor<IDbCommunication>()
                .Setup(x => x.ExecuteList("info"))
                .Returns(new List<string>
                {
                    "Test1",
                    "Test2"
                });
        }

        protected override void When()
        {
            Result = SUT.ListInstances();
        }

        [Test]
        public void then_list_should_be_executed_with_info()
        {
            GetMockFor<IDbCommunication>()
                .Verify(x => x.ExecuteList("info"));
        }

        [Test]
        public void then_result_should_match_expected()
        {
            List<string> result = Result.ToList();
            List<string> expected = new List<string>
            {
                "Test1",
                "Test2"
            };

            result.ShouldLookLike(expected);
        }
    }
}