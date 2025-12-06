using MottSchottkyAnalizer.DI.Registration;

namespace MottSchottkyAnalizer.Controls.ListEditor;

[View<ListEditorView>]
public partial class ListEditorView
{
    public ListEditorView(IListEditorViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
