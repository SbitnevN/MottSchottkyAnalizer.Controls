using ElinsDataParser.Data;
using MottSchottkyAnalizer.Core.ViewModel;
using MottSchottkyAnalizer.DI.Registration;
using MottSchottkyAnalizer.Infrastructure.Files;


namespace MottSchottkyAnalizer.Controls.CustomMenu;

[ViewModel<MenuViewModel>]
public class MenuViewModel : ViewModelBase
{
    private readonly IFileService _fileService;
    private readonly IParser _parser;

    public IRelayCommand ImportCommand { get; }
    public IRelayCommand ExportCommand { get; }

    public event EventHandler<MenuViewModel, DataImportedEventArgs>? DataImported;
    public event EventHandler<MenuViewModel, DataExportedEventArgs>? DataExported;

    public MenuViewModel(IFileService fileService, IParser parser)
    {
        ImportCommand = new RelayCommand(Import);
        ExportCommand = new RelayCommand(Export);

        _fileService = fileService;
        _parser = parser;
    }

    public void Import()
    {
        string path = _fileService.SelectFile(Filters.ExperimentalFilter);
        ElinsData data = _parser.Parse(path);

        DataImported?.Invoke(this, new DataImportedEventArgs(data));
    }

    public void Export()
    {
        string path = _fileService.CreateFile("Ms", Filters.ExperimentalFilter);
        DataExported?.Invoke(this, new DataExportedEventArgs(path));
    }
}
