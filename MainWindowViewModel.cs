using Avalonia Controls;
using ReactiveUi;
using System.Collections.ObjectModel;
using System.Reactive;

namespace IndexCards{
    public class mainWindowViewModel : ReactiveObject 
    {
        private IndexCards _selectedCard;
        public ObservableCollection<IndexCards> Cards {get;} = new ObservableCollection<IndexCards>();
        public IndexCards SelectedCard{
            get => _selectedCard;
            set => this.RaiseAndSetIfChanged(ref _selectedCard, value);
        }
        public ReactiveCommand<Unit,Unit> SaveCommand{get;}
        public ReactiveCommand<Unit,Unit> ExitCommand{get;}

        public mainWindowViewModel(){
                
                Cards.Add(new IndexCard { Id = 1, Front = "Was ist 2 + 2?", Back = "4", Category = "Mathematik" });
                Cards.Add(new IndexCard { Id = 2, Front = "Was ist die Hauptstadt von Frankreich?", Back = "Paris", Category = "Geographie" });

                SaveCommand = ReactiveCommand.Create(Save);
                ExitCommand = ReactiveCommand.Create(Exit);
        }

        private void Save()
        {
// Logik zum Speichern der Karten
        }
        private void Exit()
        {
           // Logik zum Beenden der App
        }
    }
}