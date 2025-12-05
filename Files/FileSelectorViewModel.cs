using Microsoft.Win32;
using MottSchottkyAnalizer.Core.ViewModel;

namespace MottSchottkyAnalizer.Controls.Files;

internal class FileSelectorViewModel<T> : ViewModelBase where T : class
{
    public event Action<string>? OnSelected;

    public string Title { get; set; } = null!;

    public string Filter { get; set; } = "Эксперементальные данные (*.txt, *.edf)|*.txt;*.edf";

    public string? Path
    {
        get => field;
        set => Set(ref field, value);
    }

    private void SelectFile()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog()
        {
            Filter = Filter,
        };

        if (openFileDialog.ShowDialog() == true)
        {
            Path = openFileDialog.FileName;
            OnSelected?.Invoke(Path);
        }
    }
}
