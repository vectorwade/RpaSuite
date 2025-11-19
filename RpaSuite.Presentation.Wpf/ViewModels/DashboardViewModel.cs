using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hangfire;
using RpaSuite.Application.Interfaces;
using RpaSuite.Infrastructure.Scheduling.Hangfire;
using System;
using System.Threading.Tasks;

namespace RpaSuite.Presentation.Wpf.ViewModels;

public partial class DashboardViewModel : ObservableObject
{
    private readonly IRpaOrquestrador _orquestrador;

    [ObservableProperty]
    private string status = "Pronto";

    public DashboardViewModel(IRpaOrquestrador orquestrador)
    {
        _orquestrador = orquestrador;
    }

    [RelayCommand]
    private async Task ExecutarAsync()
    {
        Status = "Executando robô...";
        try
        {
            await _orquestrador.ExecutarAsync();
            Status = "Robô executado com sucesso.";
        }
        catch (Exception ex)
        {
            Status = $"Erro: {ex.Message}";
        }
    }

    [RelayCommand]
    private void Agendar()
    {
        RecurringJob.AddOrUpdate<RpaJob>("rpa-execucao-manual", job => job.ExecutarAsync(), Cron.Minutely);
        Status = "Job agendado para execução a cada minuto.";
    }
}
