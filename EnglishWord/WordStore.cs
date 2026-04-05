using System.Collections.ObjectModel;

namespace EnglishWord
{
    public record WordEntry(string Word, string Definition, string PartOfSpeech);

    public static class WordStore
    {
        public static ObservableCollection<WordEntry> Words { get; } =
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
    }
}
