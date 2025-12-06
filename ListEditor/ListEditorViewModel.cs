using MottSchottkyAnalizer.Core.Dialogs;
using MottSchottkyAnalizer.DI.Registration;

namespace MottSchottkyAnalizer.Controls.ListEditor;

[ViewModel<IListEditorViewModel>]
internal class ListEditorViewModel : DialogViewModel, IListEditorViewModel
{
    private ListEditorParameters _parameters => (ListEditorParameters)Parameters;

    public ICollection<object> Items => _parameters.Items;
}
