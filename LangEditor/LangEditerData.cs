using Reactive.Bindings;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Reactive.Linq;

namespace LangEditor {
    public class LangEditerData : INotifyPropertyChanged {
        public ReactiveProperty<List<LangTreeData>> Tree { get; set; } = new ReactiveProperty<List<LangTreeData>>();

        public ReactiveProperty<string> Text { get; set; } = new ReactiveProperty<string>();

        public LangEditerData() {
            Text.Subscribe(code => {
                if (code == null) return;
                Tree.Value = LangTreeData.grouping(code);
            });
        }
#pragma warning disable CS0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067
    }
}
