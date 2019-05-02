using System.Collections.ObjectModel;
using System.ComponentModel;
using Reactive.Bindings;
using System.Collections.Generic;
using System;
using System.Linq;

namespace LangEditor {
    public class LangTreeData : INotifyPropertyChanged {
        public ReactiveProperty<bool> IsExpanded { get; set; } = new ReactiveProperty<bool>();

        public ReactiveProperty<string> Text { get; set; } = new ReactiveProperty<string>();

        public string Value { get; set; }

        public ReactiveProperty<List<LangTreeData>> Children { get; set; } = new ReactiveProperty<List<LangTreeData>>();

        public LangTreeData(string text, bool isExpanded) {
            Text.Value = text;
            IsExpanded.Value = isExpanded;
            Children.Value = new List<LangTreeData>();
        }

#pragma warning disable CS0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067

        public static (string[], string) parseLine(string text) {
            string[] words = text.Split('=');
            if (words.Length != 2) return (new string[0], "");
            return (words[0].Split('.'), words[1]);
        }

        public static (string[], string)[] parseText(string text) =>
            text.Split(new string[] { "\r\n" }, StringSplitOptions.None)
            .Select(line => parseLine(line))
            .ToArray();

        public static List<LangTreeData> concatSingleElement(List<LangTreeData> list) {
            foreach(LangTreeData data in list) {
                if ((data.Children?.Value?.Count ?? 0) == 0) {
                } else if (data.Children.Value.Count == 1) {
                    data.Text.Value += "." + data.Children.Value[0].Text.Value;
                    data.Value = data.Children.Value[0].Value;
                    data.Children.Value = concatSingleElement(data.Children.Value[0].Children.Value);
                } else {
                    data.Children.Value = concatSingleElement(data.Children.Value);
                }
            }
            return list;
        }

        public static List<LangTreeData> grouping(string code) => concatSingleElement(groupingSub(parseText(code), 0));

        private static List<LangTreeData> groupingSub((string[], string)[] list, int lv) => list
            .Where(data => data.Item1.Length > lv)
            .GroupBy(data => data.Item1[lv])
            .Select(group => groupingChild(group, lv))
            .ToList();

        private static LangTreeData groupingChild(IGrouping<string, (string[], string)> data, int lv) {
            LangTreeData result = new LangTreeData(data.Key, false);
            (string[], string)[] child = data.ToArray();
            if (child.Length >= 1) {
                result.Children.Value = groupingSub(child, lv + 1).ToList();
            }
            String value = child.Where(tuple => tuple.Item1.Length == lv + 1).FirstOrDefault().Item2;
            result.Value = value;
            return result;
        }

        // override object.Equals
        public override bool Equals(object obj) {
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }
            LangTreeData data = (LangTreeData)obj;
            if (Text.Value != data.Text.Value) {
                return false;
            }
            if (IsExpanded.Value != data.IsExpanded.Value) {
                return false;
            }
            if (Children.Value != null && Children.Value.Equals(data.Children.Value)) {
                return false;
            }
            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode() {
            return Tuple.Create(Text, IsExpanded, Children).GetHashCode();
        }
    }
}
