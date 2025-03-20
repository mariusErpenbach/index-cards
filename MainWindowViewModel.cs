using Avalonia.Controls;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;

namespace IndexCards
{
    public class MainWindowViewModel : ReactiveObject
    {
        private IndexCard? _selectedCard; // Als nullable deklariert
        public ObservableCollection<IndexCard> Cards { get; } = new ObservableCollection<IndexCard>();

        private CardBankManagement _cardManager;

        public IndexCard? SelectedCard
        {
            get => _selectedCard;
            set => this.RaiseAndSetIfChanged(ref _selectedCard, value);
        }

        public ReactiveCommand<Unit, Unit> SaveCommand { get; }
        public ReactiveCommand<Unit, Unit> ExitCommand { get; }

        public MainWindowViewModel()
        {
            // CardBankManagement-Instanz erstellen
            string filePath = Path.Combine(AppContext.BaseDirectory, "../../../card_bank.json");
            _cardManager = new CardBankManagement(filePath);

            // Karten aus der JSON-Datei laden
            var loadedCards = _cardManager.LoadCards();
            foreach (var card in loadedCards)
            {
                Cards.Add(card);
            }

            // Befehle initialisieren
            SaveCommand = ReactiveCommand.Create(Save);
            ExitCommand = ReactiveCommand.Create(Exit);
        }

        private void Save()
        {
            // Karten in der JSON-Datei speichern
            _cardManager.SaveCards(Cards.ToList());
            Console.WriteLine("Karten erfolgreich gespeichert.");
        }

        private void Exit()
        {
            // Logik zum Beenden der App
            Environment.Exit(0);
        }
    }
}