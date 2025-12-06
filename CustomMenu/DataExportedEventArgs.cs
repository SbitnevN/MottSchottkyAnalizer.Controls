namespace MottSchottkyAnalizer.Controls.CustomMenu;

public class DataExportedEventArgs(string path) : EventArgs
{
    public string Path { get; set; } = path;
}
