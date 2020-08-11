using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using PontoDeAjuda.Configuration.Dto;

namespace PontoDeAjuda.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : PontoDeAjudaAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
