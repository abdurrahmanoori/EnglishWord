namespace EnglishWord
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("AddWordPage", typeof(AddWordPage));
            Routing.RegisterRoute("WordDetailPage", typeof(WordDetailPage));
            Routing.RegisterRoute("QuizPage", typeof(QuizPage));
        }
    }
}
