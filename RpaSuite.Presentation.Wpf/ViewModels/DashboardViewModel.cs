using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hangfire;
using Hangfire.Common;
using RpaSuite.Application.Interfaces;
using RpaSuite.Infrastructure.Scheduling.Hangfire;
using System;
using System.Threading.Tasks;

namespace RpaSuite.Presentation.Wpf.ViewModels;

public partial class DashboardViewModel : ObservableObject
{
    private readonly IRpaOrquestrador _orquestrador;
    private readonly IRecurringJobManager _recurringJobManager;

    [ObservableProperty]
    private string status = "Pronto";

    public DashboardViewModel(IRpaOrquestrador orquestrador, IRecurringJobManager recurringJobManager)
    {
        _orquestrador = orquestrador;
        _recurringJobManager = recurringJobManager;
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
        var job = Job.FromExpression<RpaJob>(j => j.ExecutarAsync());
        _recurringJobManager.AddOrUpdate("rpa-execucao-manual", job, Cron.Minutely(), new RecurringJobOptions());
        Status = "Job agendado para execução a cada minuto.";
    }
}
