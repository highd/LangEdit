using System.Collections.ObjectModel;
using System.ComponentModel;
using Reactive.Bindings;
using System.Collections.Generic;

namespace LangEditor {
    public class LangData : INotifyPropertyChanged {
        public ReactiveProperty<bool> IsExpanded { get; set; } = new ReactiveProperty<bool>();

        public ReactiveProperty<string> Text { get; set; } = new ReactiveProperty<string>();

        public ReactiveProperty<LangData> Parent { get; set; } = new ReactiveProperty<LangData>();

        public ReactiveProperty<List<LangData>> Children { get; set; } = new ReactiveProperty<List<LangData>>();

        public LangData(string text, bool isExpanded) {
            Text.Value = text;
            IsExpanded.Value = isExpanded;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name) {
            if (null == this.PropertyChanged) return;
            this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public void Add(LangData child) {
            if (null == Children.Value) Children.Value = new List<LangData>();
            child.Parent.Value = this;
            Children.Value.Add(child);
        }
    }
}
