using Microsoft.UI.Xaml;

namespace Astrolabe.AppSDK;

public static class AppSdkWindow
{
    private static Window _mainWindow;

    public static Window Current => Get();

    private static Window Get()
    {
        if (_mainWindow is null)
        {
            _mainWindow = new MainWindow();
            _mainWindow.Activate();    
        }

        return _mainWindow;
    }
}