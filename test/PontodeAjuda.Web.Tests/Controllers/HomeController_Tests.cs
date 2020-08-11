using System.Threading.Tasks;
using PontodeAjuda.Web.Controllers;
using Shouldly;
using Xunit;

namespace PontodeAjuda.Web.Tests.Controllers
{
    public class HomeController_Tests: PontodeAjudaWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
