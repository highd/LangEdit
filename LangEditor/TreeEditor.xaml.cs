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
            var item1 = new LangData("Item1", true);
            var item11 = new LangData("Item1-1", true);
            var item12 = new LangData("Item1-2", true);
            var item2 = new LangData("Item2", false);
            var item21 = new LangData("Item2-1", true);
            TreeRoot.Add(item1);
            TreeRoot.Add(item2);
            item1.Add(item11);
            item1.Add(item12);
            item2.Add(item21);

            DataContext = this;
        }
    }
}
