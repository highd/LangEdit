using Reactive.Bindings;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Reactive.Linq;

namespace LangEditor {
    public class LangEditerData : INotifyPropertyChanged {
        public ReactiveProperty<List<LangTreeData>> Tree { get; set; } = new ReactiveProperty<List<LangTreeData>>();

        public ReactiveProperty<string> Text { get; set; } = new ReactiveProperty<string>();

        public ReactiveProperty<string> Out { get; set; }

        public LangEditerData() {
            Text.Subscribe(code => {
                if (code == null) return;
                Tree.Value = LangTreeData.grouping(code);
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
