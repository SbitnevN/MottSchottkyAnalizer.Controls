using ElinsData.Data;

namespace MottSchottkyAnalizer.Controls.CustomMenu;

public class DataImportedEventArgs(ElinsRecord data) : EventArgs
{
    public ElinsRecord Data { get; set; } = data;
}
