namespace EnglishWord
{
    public partial class AddWordPage : ContentPage
    {
        public AddWordPage()
        {
            InitializeComponent();
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var word = WordEntry.Text?.Trim();
            var definition = DefinitionEntry.Text?.Trim();
            var partOfSpeech = PartOfSpeechEntry.Text?.Trim();

            if (string.IsNullOrEmpty(word) || string.IsNullOrEmpty(definition) || string.IsNullOrEmpty(partOfSpeech))
            {
                await DisplayAlert("Validation", "Please fill in all fields.", "OK");
                return;
            }

            WordStore.Words.Add(new WordEntry(word, definition, partOfSpeech));
            await Shell.Current.GoToAsync("..");
        }
    }
}
