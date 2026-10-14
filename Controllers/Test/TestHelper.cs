using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Database;

namespace RaceDayAPI.Tests
{
    public static class TestHelper
    {
        public static RaceDayContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<RaceDayContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new RaceDayContext(options);
        }
    }
}
