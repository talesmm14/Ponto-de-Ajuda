using PontodeAjuda.EntityFrameworkCore;

namespace PontodeAjuda.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly PontodeAjudaDbContext _context;

        public TestDataBuilder(PontodeAjudaDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}