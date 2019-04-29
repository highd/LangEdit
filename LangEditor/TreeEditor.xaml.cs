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
    }
}
