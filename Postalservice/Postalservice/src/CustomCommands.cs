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

        public static readonly RoutedUICommand Ok = new RoutedUICommand(
            "Ok",
            "Ok",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Enter, ModifierKeys.Alt)
            });

        public static readonly RoutedUICommand Cancel = new RoutedUICommand(
            "Cancel",
            "Cancel",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Escape, ModifierKeys.Alt)
            });

        public static readonly RoutedUICommand From = new RoutedUICommand(
           "From",
           "From",
           typeof(CustomCommands),
           new InputGestureCollection()
           {
                new KeyGesture(Key.F, ModifierKeys.Alt)
           });

        public static readonly RoutedUICommand To = new RoutedUICommand(
           "To",
           "To",
           typeof(CustomCommands),
           new InputGestureCollection()
           {
                new KeyGesture(Key.T, ModifierKeys.Alt)
           });

        public static readonly RoutedUICommand ManagePackages = new RoutedUICommand(
           "ManagePackages",
           "ManagePackages",
           typeof(CustomCommands),
           new InputGestureCollection()
           {
                new KeyGesture(Key.P, ModifierKeys.Alt)
           });

        public static readonly RoutedUICommand ManageVehicles = new RoutedUICommand(
           "ManageVehicles",
           "ManageVehicles",
           typeof(CustomCommands),
           new InputGestureCollection()
           {
                new KeyGesture(Key.V, ModifierKeys.Alt)
           });

        public static readonly RoutedUICommand ManageTransports = new RoutedUICommand(
           "ManageTransports",
           "ManageTransports",
           typeof(CustomCommands),
           new InputGestureCollection()
           {
                new KeyGesture(Key.T, ModifierKeys.Alt)
           });

        public static readonly RoutedUICommand CheckOut = new RoutedUICommand(
           "CheckOut",
           "CheckOut",
           typeof(CustomCommands),
           new InputGestureCollection()
           {
                new KeyGesture(Key.C, ModifierKeys.Alt)
           });

        public static readonly RoutedUICommand AddParcel = new RoutedUICommand(
           "AddParcel",
           "AddParcel",
           typeof(CustomCommands),
           new InputGestureCollection()
           {
                new KeyGesture(Key.A, ModifierKeys.Alt)
           });

        public static readonly RoutedUICommand ManageTab = new RoutedUICommand(
           "ManageTab",
           "ManageTab",
           typeof(CustomCommands),
           new InputGestureCollection()
           {
                new KeyGesture(Key.M, ModifierKeys.Alt)
           });

        public static readonly RoutedUICommand AddTab = new RoutedUICommand(
           "AddTab",
           "AddTab",
           typeof(CustomCommands),
           new InputGestureCollection()
           {
                new KeyGesture(Key.A, ModifierKeys.Alt)
           });

        public static readonly RoutedUICommand PackTab = new RoutedUICommand(
           "PackTab",
           "PackTab",
           typeof(CustomCommands),
           new InputGestureCollection()
           {
                new KeyGesture(Key.A, ModifierKeys.Alt)
           });

        public static readonly RoutedUICommand Arrival = new RoutedUICommand(
          "Arrival",
          "Arrival",
          typeof(CustomCommands),
          new InputGestureCollection()
          {
                new KeyGesture(Key.A, ModifierKeys.Alt)
          });

        public static readonly RoutedUICommand Depart = new RoutedUICommand(
          "Depart",
          "Depart",
          typeof(CustomCommands),
          new InputGestureCollection()
          {
                new KeyGesture(Key.D, ModifierKeys.Alt)
          });

        public static readonly RoutedUICommand ClearStorageFilter = new RoutedUICommand(
          "ClearStorageFilter",
          "ClearStorageFilter",
          typeof(CustomCommands),
          new InputGestureCollection()
          {
                new KeyGesture(Key.S, ModifierKeys.Alt)
          });

        public static readonly RoutedUICommand PackAll = new RoutedUICommand(
          "PackAll",
          "PackAll",
          typeof(CustomCommands),
          new InputGestureCollection()
          {
                new KeyGesture(Key.K, ModifierKeys.Alt)
          });

        public static readonly RoutedUICommand ClearFilter = new RoutedUICommand(
          "ClearFilter",
          "ClearFilter",
          typeof(CustomCommands),
          new InputGestureCollection()
          {
                new KeyGesture(Key.C, ModifierKeys.Alt)
          });

        public static readonly RoutedUICommand UnpackAll = new RoutedUICommand(
          "UnpackAll",
          "UnpackAll",
          typeof(CustomCommands),
          new InputGestureCollection()
          {
                new KeyGesture(Key.U, ModifierKeys.Alt)
          });

        public static readonly RoutedUICommand VehiclesTab = new RoutedUICommand(
          "VehiclesTab",
          "VehiclesTab",
          typeof(CustomCommands),
          new InputGestureCollection()
          {
                new KeyGesture(Key.V, ModifierKeys.Alt)
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
