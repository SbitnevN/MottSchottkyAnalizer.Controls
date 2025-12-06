using ElinsDataParser.Data;

namespace MottSchottkyAnalizer.Controls.CustomMenu;

public class DataImportedEventArgs(ElinsData data) : EventArgs
{
    public ElinsData Data { get; set; } = data;
}
