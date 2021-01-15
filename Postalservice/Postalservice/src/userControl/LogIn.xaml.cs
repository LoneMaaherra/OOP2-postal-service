using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Postalservice.src.userControl
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : UserControl
    {
        /// <summary>
        /// Command for LogIn left button.
        /// </summary>
        public ICommand LeftButtonCommand
        {
            get { return (ICommand)this.GetValue(LeftButtonCommandProperty); }
            set { this.SetValue(LeftButtonCommandProperty, value); }
        }
        /// <summary>
        /// Dependency register for left button command property.
        /// </summary>
        public static readonly DependencyProperty LeftButtonCommandProperty = DependencyProperty.Register(
            "LeftButtonCommand", typeof(ICommand), typeof(LogIn), new PropertyMetadata());

        /// <summary>
        /// Command for LogIn right button.
        /// </summary>
        public ICommand RightButtonCommand
        {
            get { return (ICommand)this.GetValue(RightButtonCommandProperty); }
            set { this.SetValue(RightButtonCommandProperty, value); }
        }
        /// <summary>
        /// Dependency register for right button command property.
        /// </summary>
        public static readonly DependencyProperty RightButtonCommandProperty = DependencyProperty.Register(
            "RightButtonCommand", typeof(ICommand), typeof(LogIn), new PropertyMetadata());

        /// <summary>
        /// Content property of the left button.
        /// </summary>
        public object LeftButtonContent
        {
            get { return (object)this.GetValue(LeftButtonContentProperty); }
            set { this.SetValue(LeftButtonContentProperty, value); }
        }
        /// <summary>
        /// Dependency register for LeftButtonContent property.
        /// </summary>
        public static readonly DependencyProperty LeftButtonContentProperty = DependencyProperty.Register(
            "LeftButtonContent", typeof(object), typeof(LogIn), new PropertyMetadata());

        /// <summary>
        /// Content property of the right button.
        /// </summary>
        public object RightButtonContent
        {
            get { return (object)this.GetValue(RightButtonContentProperty); }
            set { this.SetValue(RightButtonContentProperty, value); }
        }
        /// <summary>
        /// Dependency register for RightButtonContent property.
        /// </summary>
        public static readonly DependencyProperty RightButtonContentProperty = DependencyProperty.Register(
            "RightButtonContent", typeof(object), typeof(LogIn), new PropertyMetadata());

        /// <summary>
        /// Visibility property of LogIn left button.
        /// </summary>
        public Visibility LeftButtonVisibility
        {
            get { return (Visibility)this.GetValue(LeftButtonVisibilityProperty); }
            set { this.SetValue(LeftButtonVisibilityProperty, value); }
        }
        /// <summary>
        /// Dependency register for LeftButtonVisibility property.
        /// </summary>
        public static readonly DependencyProperty LeftButtonVisibilityProperty = DependencyProperty.Register(
            "LeftButtonVisibility", typeof(Visibility), typeof(LogIn), new PropertyMetadata());

        /// <summary>
        /// Visibility property of LogIn right button.
        /// </summary>
        public Visibility RightButtonVisibility
        {
            get { return (Visibility)this.GetValue(RightButtonVisibilityProperty); }
            set { this.SetValue(RightButtonVisibilityProperty, value); }
        }
        /// <summary>
        /// Dependency register for RightButtonVisibility property.
        /// </summary>
        public static readonly DependencyProperty RightButtonVisibilityProperty = DependencyProperty.Register(
            "RightButtonVisibility", typeof(Visibility), typeof(LogIn), new PropertyMetadata());

        /// <summary>
        /// Visibility property of the top label and textbox.
        /// </summary>
        public Visibility TopInsertVisibility
        {
            get { return (Visibility)this.GetValue(TopInsertVisibilityProperty); }
            set { this.SetValue(TopInsertVisibilityProperty, value); }
        }
        /// <summary>
        /// Dependency register for TopInsertVisibility property.
        /// </summary>
        public static readonly DependencyProperty TopInsertVisibilityProperty = DependencyProperty.Register(
            "TopInsertVisibility", typeof(Visibility), typeof(LogIn), new PropertyMetadata());

        /// <summary>
        /// Visibility property of the bottom label and textbox.
        /// </summary>
        public Visibility BottomInsertVisibility
        {
            get { return (Visibility)this.GetValue(BottomInsertVisibilityProperty); }
            set { this.SetValue(BottomInsertVisibilityProperty, value); }
        }
        /// <summary>
        /// Dependency register for BottomInsertVisibility property.
        /// </summary>
        public static readonly DependencyProperty BottomInsertVisibilityProperty = DependencyProperty.Register(
            "BottomInsertVisibility", typeof(Visibility), typeof(LogIn), new PropertyMetadata());

        /// <summary>
        /// Visibility property of the password label and textbox.
        /// </summary>
        public Visibility PasswordInsertVisibility
        {
            get { return (Visibility)this.GetValue(PasswordInsertVisibilityProperty); }
            set { this.SetValue(PasswordInsertVisibilityProperty, value); }
        }
        /// <summary>
        /// Dependency register for PasswordInsertVisibility property.
        /// </summary>
        public static readonly DependencyProperty PasswordInsertVisibilityProperty = DependencyProperty.Register(
            "PasswordInsertVisibility", typeof(Visibility), typeof(LogIn), new PropertyMetadata());

        /// <summary>
        /// Visibility property of the error message.
        /// </summary>
        public Visibility ErrorMessageVisibility
        {
            get { return (Visibility)this.GetValue(ErrorMessageVisibilityProperty); }
            set { this.SetValue(ErrorMessageVisibilityProperty, value); }
        }
        /// <summary>
        /// Dependency register for ErrorMessageVisibility property.
        /// </summary>
        public static readonly DependencyProperty ErrorMessageVisibilityProperty = DependencyProperty.Register(
            "ErrorMessageVisibility", typeof(Visibility), typeof(LogIn), new PropertyMetadata());

        /// <summary>
        /// Content property of the top label.
        /// </summary>
        public string TopLabelContent
        {
            get { return (string)this.GetValue(TopLabelContentProperty); }
            set { this.SetValue(TopLabelContentProperty, value); }
        }
        /// <summary>
        /// Dependency register for TopLabelContent property.
        /// </summary>
        public static readonly DependencyProperty TopLabelContentProperty = DependencyProperty.Register(
            "TopLabelContent", typeof(string), typeof(LogIn), new PropertyMetadata());

        /// <summary>
        /// Content property of the bottom label.
        /// </summary>
        public string BottomLabelContent
        {
            get { return (string)this.GetValue(BottomLabelContentProperty); }
            set { this.SetValue(BottomLabelContentProperty, value); }
        }
        /// <summary>
        /// Dependency register for BottomLabelContent property.
        /// </summary>
        public static readonly DependencyProperty BottomLabelContentProperty = DependencyProperty.Register(
            "BottomLabelContent", typeof(string), typeof(LogIn), new PropertyMetadata());

        /// <summary>
        /// Content property of the password label.
        /// </summary>
        public string PasswordLabelContent
        {
            get { return (string)this.GetValue(PasswordLabelContentProperty); }
            set { this.SetValue(PasswordLabelContentProperty, value); }
        }
        /// <summary>
        /// Dependency register for PasswordLabelContent property.
        /// </summary>
        public static readonly DependencyProperty PasswordLabelContentProperty = DependencyProperty.Register(
            "PasswordLabelContent", typeof(string), typeof(LogIn), new PropertyMetadata());

        /// <summary>
        /// Content property of the error message label.
        /// </summary>
        public string ErrorMessageContent
        {
            get { return (string)this.GetValue(ErrorMessageContentProperty); }
            set { this.SetValue(ErrorMessageContentProperty, value); }
        }
        /// <summary>
        /// Dependency register for ErrorMessageContent property.
        /// </summary>
        public static readonly DependencyProperty ErrorMessageContentProperty = DependencyProperty.Register(
            "ErrorMessageContent", typeof(string), typeof(LogIn), new PropertyMetadata());

        /// <summary>
        /// Content property of the top textbox.
        /// </summary>
        public string TopTextBoxContent
        {
            get { return (string)this.GetValue(TopTextBoxContentProperty); }
            set { this.SetValue(TopTextBoxContentProperty, value); }
        }
        /// <summary>
        /// Dependency register for TopTextBoxContent property.
        /// </summary>
        public static readonly DependencyProperty TopTextBoxContentProperty = DependencyProperty.Register(
            "TopTextBoxContent", typeof(string), typeof(LogIn), new PropertyMetadata());

        /// <summary>
        /// Content property of the bottom textbox.
        /// </summary>
        public string BottomTextBoxContent
        {
            get { return (string)this.GetValue(BottomTextBoxContentProperty); }
            set { this.SetValue(BottomTextBoxContentProperty, value); }
        }
        /// <summary>
        /// Dependency register for BottomTextBoxContent property.
        /// </summary>
        public static readonly DependencyProperty BottomTextBoxContentProperty = DependencyProperty.Register(
            "BottomTextBoxContent", typeof(string), typeof(LogIn), new PropertyMetadata());

        /// <summary>
        /// Content property of the textbox and passwordbox font color.
        /// </summary>
        public SolidColorBrush TextBoxForeground
        {
            get { return (SolidColorBrush)this.GetValue(TextBoxForegroundProperty); }
            set { this.SetValue(TextBoxForegroundProperty, value); }
        }
        /// <summary>s
        /// Dependency register for TextBoxForeground property.
        /// </summary>
        public static readonly DependencyProperty TextBoxForegroundProperty = DependencyProperty.Register(
            "TextBoxForeground", typeof(SolidColorBrush), typeof(LogIn), new PropertyMetadata());

        /// <summary>
        /// Content property of the textbox and passwordbox labels font color.
        /// </summary>
        public SolidColorBrush LabelForeground
        {
            get { return (SolidColorBrush)this.GetValue(LabelForegroundProperty); }
            set { this.SetValue(LabelForegroundProperty, value); }
        }
        /// <summary>s
        /// Dependency register for LabelForeground property.
        /// </summary>
        public static readonly DependencyProperty LabelForegroundProperty = DependencyProperty.Register(
            "LabelForeground", typeof(SolidColorBrush), typeof(LogIn), new PropertyMetadata());

        /// <summary>
        /// Color property of the error message.
        /// </summary>
        public SolidColorBrush ErrorMessageForeground
        {
            get { return (SolidColorBrush)this.GetValue(ErrorMessageForegroundProperty); }
            set { this.SetValue(ErrorMessageForegroundProperty, value); }
        }
        /// <summary>s
        /// Dependency register for ErrorMessageForeground property.
        /// </summary>
        public static readonly DependencyProperty ErrorMessageForegroundProperty = DependencyProperty.Register(
            "ErrorMessageForeground", typeof(SolidColorBrush), typeof(LogIn), new PropertyMetadata());

        /// <summary>
        /// Instantiates a Login object.
        /// </summary>
        public LogIn()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Returns the input from the password box.
        /// </summary>
        /// <returns></returns>
        public SecureString GetPassword()
        {
            return PwordBox.SecurePassword;
        }

        /// <summary>
        /// Clears the password box filed.
        /// </summary>
        public void EmptyPasswordField()
        {
            PwordBox.Clear();
        }

        /// <summary>
        /// Clears all input fields.
        /// </summary>
        public void ClearAllFields()
        {
            TextBoxTop.Clear();
            TextBoxBottom.Clear();
            EmptyPasswordField();
        }

        /// <summary>
        /// HIdes the error message and clears all input fields.
        /// </summary>
        public void Reset()
        {
            TextBlockErrorMessage.Visibility = Visibility.Hidden;
            ClearAllFields();
        }
    }
}
