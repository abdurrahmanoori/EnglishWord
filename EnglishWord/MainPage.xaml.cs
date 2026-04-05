using System.Collections.ObjectModel;

namespace EnglishWord
{
    public partial class MainPage : ContentPage
    {
        private readonly List<WordEntry> _allWords =
        [
            new("Abundant", "Existing in large quantities", "Adjective"),
            new("Benevolent", "Well meaning and kindly", "Adjective"),
            new("Candid", "Truthful and straightforward", "Adjective"),
            new("Diligent", "Having or showing care in work", "Adjective"),
            new("Eloquent", "Fluent or persuasive in speaking", "Adjective"),
            new("Flourish", "Grow or develop in a healthy way", "Verb"),
            new("Gratitude", "The quality of being thankful", "Noun"),
            new("Humble", "Having a modest opinion of oneself", "Adjective"),
        ];

        public ObservableCollection<WordEntry> Words { get; } = [];

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            foreach (var w in _allWords) Words.Add(w);
        }

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            var query = e.NewTextValue?.ToLowerInvariant() ?? string.Empty;
            Words.Clear();
            foreach (var w in _allWords.Where(x =>
                x.Word.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                x.Definition.Contains(query, StringComparison.OrdinalIgnoreCase)))
                Words.Add(w);
        }
    }

    public record WordEntry(string Word, string Definition, string PartOfSpeech);
}
