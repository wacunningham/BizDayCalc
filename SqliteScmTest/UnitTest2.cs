using System.Linq;
using Xunit;
using WidgetScmDataAcess;
using Xunit.Abstractions;

namespace SqliteScmTest
{
   public class UnitTest2 :IClassFixture<SampleScmDataFixture>
    {
        private SampleScmDataFixture fixture;

        private readonly ITestOutputHelper output;

        private ScmContext context;
        
        public UnitTest2(SampleScmDataFixture fixture , ITestOutputHelper output)
        {
            this.fixture = fixture;
            this.context = new ScmContext(fixture.Connection);
            this.output = output;
        }

        //Test parts only has 1 item
        [Fact]
        public void Test1()
        {
            var parts = context.Parts;
            output.WriteLine($@"Number of parts""{parts.Count()}""");
            Assert.Single(parts);
            var part = parts.First();
            output.WriteLine($@"PartType name""{part.Name}""");
            Assert.Equal("8289 L-shaped plate", part.Name);
        }
    }
}
