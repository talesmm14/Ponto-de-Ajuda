using System.Threading.Tasks;
using PontoDeAjuda.Models.TokenAuth;
using PontoDeAjuda.Web.Controllers;
using Shouldly;
using Xunit;

namespace PontoDeAjuda.Web.Tests.Controllers
{
    public class HomeController_Tests: PontoDeAjudaWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}