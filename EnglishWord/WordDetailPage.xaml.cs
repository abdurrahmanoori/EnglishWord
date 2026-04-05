namespace EnglishWord
{
    [QueryProperty(nameof(WordIndex), "index")]
    public partial class WordDetailPage : ContentPage
    {
        private int _wordIndex;

        public int WordIndex
        {
            set
            {
                _wordIndex = value;
                var entry = WordStore.Words[value];
                WordLabel.Text = entry.Word;
                DefinitionLabel.Text = entry.Definition;
                PartOfSpeechLabel.Text = entry.PartOfSpeech;
            }
        }

        public WordDetailPage()
        {
            InitializeComponent();
        }

        private async void OnQuizClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"QuizPage?index={_wordIndex}");
        }
    }
}
