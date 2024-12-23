using Microsoft.Win32;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace TextEditor.ViewModels
{

    public class MainViewModel : ViewModelBase
    {
        private string _content;
        private FontFamily _selectedFontFamily;
        private double _selectedFontSize;
        private FontWeight _selectedFontWeight;
        private FontStyle _selectedFontStyle;
        private bool _isBold;
        private bool _isItalic;
        private bool _isUnderline;

        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged(nameof(Content));
            }
        }

        public FontFamily SelectedFontFamily
        {
            get => _selectedFontFamily;
            set
            {
                _selectedFontFamily = value;
                OnPropertyChanged(nameof(SelectedFontFamily));
            }
        }

        public double SelectedFontSize
        {
            get => _selectedFontSize;
            set
            {
                _selectedFontSize = value;
                OnPropertyChanged(nameof(SelectedFontSize));
            }
        }

        public FontWeight SelectedFontWeight
        {
            get => _selectedFontWeight;
            set
            {
                _selectedFontWeight = value;
                OnPropertyChanged(nameof(SelectedFontWeight));
            }
        }

        public FontStyle SelectedFontStyle
        {
            get => _selectedFontStyle;
            set
            {
                _selectedFontStyle = value;
                OnPropertyChanged(nameof(SelectedFontStyle));
            }
        }

        public bool IsBold
        {
            get => _isBold;
            set
            {
                _isBold = value;
                SelectedFontWeight = value ? FontWeights.Bold : FontWeights.Normal;
                OnPropertyChanged(nameof(IsBold));
            }
        }

        public bool IsItalic
        {
            get => _isItalic;
            set
            {
                _isItalic = value;
                SelectedFontStyle = value ? FontStyles.Italic : FontStyles.Normal;
                OnPropertyChanged(nameof(IsItalic));
            }
        }

        public bool IsUnderline
        {
            get => _isUnderline;
            set
            {
                _isUnderline = value;
                OnPropertyChanged(nameof(IsUnderline));
            }
        }

        public ICommand OpenFileCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand CopyCommand { get; }
        public ICommand PasteCommand { get; }
        public ICommand CutCommand { get; }
        public ICommand SelectAllCommand { get; }
        public ICommand ChooseFontCommand { get; }
        public ICommand ChangeFontSizeCommand { get; }
        public ICommand ToggleBoldCommand { get; }
        public ICommand ToggleItalicCommand { get; }
        public ICommand ToggleUnderlineCommand { get; }
        public ICommand LightThemeCommand { get; }
        public ICommand DarkThemeCommand { get; }

        public MainViewModel()
        {
            OpenFileCommand = new RelayCommand(OpenFile);
            SaveAsCommand = new RelayCommand(SaveAs);
            SaveCommand = new RelayCommand(Save);
            CopyCommand = new RelayCommand(Copy);
            PasteCommand = new RelayCommand(Paste);
            CutCommand = new RelayCommand(Cut);
            SelectAllCommand = new RelayCommand(SelectAll);
            ChooseFontCommand = new RelayCommand(ChooseFont);
            ChangeFontSizeCommand = new RelayCommand(ChangeFontSize);
            ToggleBoldCommand = new RelayCommand(ToggleBold);
            ToggleItalicCommand = new RelayCommand(ToggleItalic);
            ToggleUnderlineCommand = new RelayCommand(ToggleUnderline);
            LightThemeCommand = new RelayCommand(SetLightTheme);
            DarkThemeCommand = new RelayCommand(SetDarkTheme);

            SelectedFontFamily = new FontFamily("Arial");
            SelectedFontSize = 12;
            SelectedFontWeight = FontWeights.Normal;
            SelectedFontStyle = FontStyles.Normal;
            IsBold = false;
            IsItalic = false;
            IsUnderline = false;
        }

        private void OpenFile(object obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                Content = System.IO.File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveAs(object obj)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                System.IO.File.WriteAllText(saveFileDialog.FileName, Content);
            }
        }

        private void Save(object obj)
        {

        }

        private void Copy(object obj) => Clipboard.SetText(Content);
        private void Paste(object obj) => Content += Clipboard.GetText();
        private void Cut(object obj) => Content = string.Empty;

        private void SelectAll(object obj) => Content = Content;

        private void ChooseFont(object obj)
        {

        }
        private void ChangeFontSize(object fontSize)
        {
            if (fontSize is string sizeStr && double.TryParse(sizeStr, out double size))
            {
                SelectedFontSize = size;
            }
        }

        private void ToggleBold(object obj)
        {
            IsBold = !IsBold;
        }

        private void ToggleItalic(object obj)
        {
            IsItalic = !IsItalic;
        }

        private void ToggleUnderline(object obj)
        {
            IsUnderline = !IsUnderline;
        }
        private void SetLightTheme(object obj)
        {
            Application.Current.Resources["PrimaryBackgroundColor"] = new SolidColorBrush(Colors.White);
            Application.Current.Resources["PrimaryForegroundColor"] = new SolidColorBrush(Colors.Black);
        }

        private void SetDarkTheme(object obj)
        {
            Application.Current.Resources["PrimaryBackgroundColor"] = new SolidColorBrush(Colors.Black);
            Application.Current.Resources["PrimaryForegroundColor"] = new SolidColorBrush(Colors.White);
        }
    }
}

