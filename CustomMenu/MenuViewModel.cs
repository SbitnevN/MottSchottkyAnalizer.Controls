using ElinsData.Data;
using MottSchottkyAnalizer.Core.ViewModel;
using MottSchottkyAnalizer.DI.Registration;
using MottSchottkyAnalizer.Infrastructure.Files;


namespace MottSchottkyAnalizer.Controls.CustomMenu;

[ViewModel<MenuViewModel>]
public class MenuViewModel : ViewModelBase
{
    private readonly IFileService _fileService;

    public IRelayCommand ImportCommand { get; }
    public IRelayCommand ExportCommand { get; }

    public event EventHandler<MenuViewModel, DataImportedEventArgs>? DataImported;
    public event EventHandler<MenuViewModel, DataExportedEventArgs>? DataExported;

    public MenuViewModel(IFileService fileService)
    {
        ImportCommand = new RelayCommand(Import);
        ExportCommand = new RelayCommand(Export);

        _fileService = fileService;
    }

    public void Import()
    {
        string path = _fileService.SelectFile(Filters.ExperimentalFilter);
        ElinsRecord data = ElinsFactory.Create(path);

        DataImported?.Invoke(this, new DataImportedEventArgs(data));
    }

    public void Export()
    {
        string path = _fileService.CreateFile("Ms", Filters.ExperimentalFilter);
        DataExported?.Invoke(this, new DataExportedEventArgs(path));
    }
}
