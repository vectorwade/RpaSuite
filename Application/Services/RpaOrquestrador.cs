using RpaSuite.Application.Interfaces;
using RpaSuite.Infrastructure.Integrations.Rest;
using RpaSuite.Infrastructure.Integrations.Soap;
using RpaSuite.Infrastructure.Integrations.Sftp;
using RpaSuite.Infrastructure.Automation.Selenium;

namespace RpaSuite.Application.Services;

public class RpaOrquestrador : IRpaOrquestrador
{
    private readonly IRestClient _rest;
    private readonly ISoapClient _soap;
    private readonly ISftpClientService _sftp;
    private readonly ISeleniumRunner _selenium;

    public RpaOrquestrador(IRestClient rest, ISoapClient soap, ISftpClientService sftp, ISeleniumRunner selenium)
    {
        _rest = rest;
        _soap = soap;
        _sftp = sftp;
        _selenium = selenium;
    }

    public async Task ExecutarAsync()
    {
        var dados = await _rest.GetAsync<object>("dados");
        await _soap.EnviarAsync(new { Id = 1 });
        _sftp.Upload("local.csv", "/remote.csv");

        _selenium.Navigate("https://sistema.com");
        _selenium.InjectJs("console.log('Robô executado via WPF');");
    }
}
