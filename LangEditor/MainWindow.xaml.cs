using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LangEditor {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public LangEditerData Data { get; set; } = new LangEditerData();

        public MainWindow() {
            InitializeComponent();
            treeEditer.Data = Data;
            tab2.DataContext = Data;
            Data.Text.Value = "aaa=199";
        }

        private void FileOpenMenuClick(object sender, RoutedEventArgs e) {

        }

        private void FileSaveMenuClick(object sender, RoutedEventArgs e) {

        }

        private void FileNameSaveMenuClick(object sender, RoutedEventArgs e) {

        }
    }
}
