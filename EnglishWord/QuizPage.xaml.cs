namespace EnglishWord
{
    [QueryProperty(nameof(WordIndex), "index")]
    public partial class QuizPage : ContentPage
    {
        private int _currentIndex;
        private readonly Random _random = new();

        public int WordIndex
        {
            set => LoadWord(value);
        }

        public QuizPage()
        {
            InitializeComponent();
            LoadWord(_random.Next(WordStore.Words.Count));
        }

        private void LoadWord(int index)
        {
            _currentIndex = index;
            QuizWordLabel.Text = WordStore.Words[index].Word;
            AnswerEntry.Text = string.Empty;
            ResultFrame.IsVisible = false;
        }

        private void OnCheckClicked(object sender, EventArgs e)
        {
            var answer = AnswerEntry.Text?.Trim() ?? string.Empty;
            var correct = WordStore.Words[_currentIndex].Definition;
            var isCorrect = correct.Contains(answer, StringComparison.OrdinalIgnoreCase) && answer.Length > 3;

            ResultFrame.IsVisible = true;
            ResultFrame.BackgroundColor = isCorrect ? Colors.LightGreen : Colors.LightCoral;
            ResultLabel.Text = isCorrect ? $"✓ Correct! \"{correct}\"" : $"✗ Not quite. The answer is: \"{correct}\"";
        }

        private void OnNextClicked(object sender, EventArgs e)
        {
            var next = _random.Next(WordStore.Words.Count);
            LoadWord(next);
        }
    }
}
