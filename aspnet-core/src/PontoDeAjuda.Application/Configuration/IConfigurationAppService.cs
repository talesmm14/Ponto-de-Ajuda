using System.Threading.Tasks;
using PontoDeAjuda.Configuration.Dto;

namespace PontoDeAjuda.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
