using MottSchottkyAnalizer.Core.Dialogs;

namespace MottSchottkyAnalizer.Controls.ListEditor;

public class ListEditorParameters : DialogParameters
{
    public ICollection<object> Items { get; init; } = null!;
}
