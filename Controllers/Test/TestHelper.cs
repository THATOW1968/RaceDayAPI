using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Database;

namespace RaceDayAPI.Tests
{//start of namespace
    public static class TestHelper
    {//start of class
        public static RaceDayContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<RaceDayContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new RaceDayContext(options);
        }
    }
}
