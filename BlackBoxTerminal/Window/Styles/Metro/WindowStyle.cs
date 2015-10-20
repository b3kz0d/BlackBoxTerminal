using System.Windows;
using System.Windows.Input;

namespace BlackBoxTerminal.Window.Styles.Metro
{
    public partial class WindowStyle
    {
        private System.Windows.Window _window;

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            _window = ((System.Windows.Window)sender);
        }

        private void MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(_window!=null&&e.ButtonState==MouseButtonState.Pressed)
            _window.DragMove();
        }

        
    }
}
