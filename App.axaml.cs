// Avalonia allows creating a cross-platform desktop application.
using Avalonia;

namespace IndexCards{
    // "App" inherits from Avalonia's "Application" base class.
    public class App : Application{
        
        // Initialize method loads the XAML UI.
        public override void Initialize(){
            AvaloniaXamlLoader.Load(this);
        }

        // Called after framework initialization.
        public override void OnFrameworkInitializationCompleted(){
            
            // Check if the app is a desktop app.
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop){
                // Set the main window for the desktop app.
                desktop.MainWindow = new MainWindow();
            }
            
            // Ensure base method completes the lifecycle.
            base.OnFrameworkInitializationCompleted();
        }
    }
}
