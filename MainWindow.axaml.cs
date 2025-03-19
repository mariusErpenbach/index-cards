using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace IndexCards{
    public partial class MainWindow : Window{
        public MainWindow(){
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void InitializeComponent(){
            AvaloniaXamlLoader.Load(this);
        }
    }
}