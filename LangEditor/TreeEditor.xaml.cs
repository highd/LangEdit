using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace LangEditor {

    /// <summary>
    /// TreeEditor.xaml の相互作用ロジック
    /// </summary>
    public partial class TreeEditor : UserControl {
        public LangEditerData Data { get; set; }
        public TreeEditor() {
            InitializeComponent();

            DataContext = this;
        }

        private void tree_SelectedItemChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<object> e) {
            if (tree.SelectedItem != null && tree.SelectedItem is LangTreeData) {
                text.Text = ((LangTreeData)tree.SelectedItem).Value;
            }
        }
    }
}
