using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Postalservice.src
{
    public class CustomCommands
    {
        public static readonly RoutedUICommand NewUser = new RoutedUICommand(
            "NewUser", 
            "NewUser", 
            typeof(CustomCommands), 
            new InputGestureCollection() 
            { 
                new KeyGesture(Key.N, ModifierKeys.Alt)
            });

        public static readonly RoutedUICommand LogIn = new RoutedUICommand(
            "LogIn",
            "LogIn",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.L, ModifierKeys.Alt)
            });

        public static readonly RoutedUICommand Return = new RoutedUICommand(
            "Return",
            "Return",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Back, ModifierKeys.Alt)
            });

        public static readonly RoutedUICommand Home = new RoutedUICommand(
            "Home",
            "Home",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Home, ModifierKeys.Alt)
            });

        public static readonly RoutedUICommand Exit = new RoutedUICommand(
            "Exit",
            "Exit",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.End, ModifierKeys.Alt)
            });

        public static String SecureStringToString(SecureString value)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }
    }
}
