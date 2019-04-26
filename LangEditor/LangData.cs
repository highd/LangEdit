using System.Collections.ObjectModel;
using System.ComponentModel;

namespace LangEditor {
    public class LangData : INotifyPropertyChanged {
        private bool _IsExpanded = true;
        private string _Text = "";
        private LangData _Parent = null;
        private ObservableCollection<LangData> _Children = null;


        public bool IsExpanded {
            get { return _IsExpanded; }
            set { _IsExpanded = value; OnPropertyChanged("IsExpanded"); }
        }

        public string Text {
            get { return _Text; }
            set { _Text = value; OnPropertyChanged("Text"); }
        }

        public LangData Parent {
            get { return _Parent; }
            set { _Parent = value; OnPropertyChanged("Parent"); }
        }

        public ObservableCollection<LangData> Children {
            get { return _Children; }
            set { _Children = value; OnPropertyChanged("Childen"); }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name) {
            if (null == this.PropertyChanged) return;
            this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public void Add(LangData child) {
            if (null == Children) Children = new ObservableCollection<LangData>();
            child.Parent = this;
            Children.Add(child);
        }
    }
}
