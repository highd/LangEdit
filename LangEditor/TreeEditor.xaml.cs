using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace LangEditor {

    /// <summary>
    /// TreeEditor.xaml の相互作用ロジック
    /// </summary>
    public partial class TreeEditor : UserControl {
        public ObservableCollection<LangData> TreeRoot { get; set; }
        public TreeEditor() {
            InitializeComponent();
            text.Text = "test Text.";
            TreeRoot = new ObservableCollection<LangData>();
            var item1 = new LangData() { Text = "Item1", IsExpanded = true };
            var item11 = new LangData() { Text = "Item1-1", IsExpanded = true };
            var item12 = new LangData() { Text = "Item1-2", IsExpanded = true };
            var item2 = new LangData() { Text = "Item2", IsExpanded = false };
            var item21 = new LangData() { Text = "Item2-1", IsExpanded = true };
            TreeRoot.Add(item1);
            TreeRoot.Add(item2);
            item1.Add(item11);
            item1.Add(item12);
            item2.Add(item21);

            DataContext = this;
        }
    }
}
