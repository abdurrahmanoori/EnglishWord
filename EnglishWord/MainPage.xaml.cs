using System.Collections.ObjectModel;
using Syncfusion.Maui.ListView;

namespace EnglishWord
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<WordEntry> Words { get; } = WordStore.Words;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            var query = e.NewTextValue?.Trim() ?? string.Empty;
            WordListView.DataSource.Filter = string.IsNullOrEmpty(query) ? null : item =>
                item is WordEntry w &&
                (w.Word.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                 w.Definition.Contains(query, StringComparison.OrdinalIgnoreCase));
            WordListView.DataSource.RefreshFilter();
        }

        private async void OnWordSelected(object sender, ItemSelectionChangedEventArgs e)
        {
            if (e.AddedItems.FirstOrDefault() is WordEntry selected)
            {
                var index = WordStore.Words.IndexOf(selected);
                WordListView.SelectedItems.Clear();
                await Shell.Current.GoToAsync($"WordDetailPage?index={index}");
            }
        }

        private async void OnAddWordClicked(object sender, EventArgs e) =>
            await Shell.Current.GoToAsync("AddWordPage");

        private async void OnQuizClicked(object sender, EventArgs e) =>
            await Shell.Current.GoToAsync("QuizPage");
    }
}
