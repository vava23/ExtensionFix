using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExtensionFix
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
  public partial class MainWindow : Window
  {
    private ExtensionFixer ExtFixer;

    public MainWindow()
    {
      InitializeComponent();
      ExtFixer = new ExtensionFixer();
    }

    //
    // Determines if the dragged object is a file
    //
    private bool FileDropped(DragEventArgs e)
    {
      return e.Data.GetDataPresent(DataFormats.FileDrop);
    }

    private void Border_Drop(object sender, DragEventArgs e)
    {
      // Check if a file was dropped
      if (FileDropped(e))
      {
        string userMessage;
        // Get the list of files
        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
        // Process every file
        int filesFixed = ExtensionFixer.ProcessFiles(files);
        switch (filesFixed)
        {
          case 0:
            userMessage = "Исправление файлов не требуется";
            break;
          case 1:
            userMessage = "Файл исправлен успешно!";
            break;
          default:
            userMessage = "Файлы исправлены успешно!";
            break;
        }
        // Notify user
        MessageBox.Show(userMessage);
      }
    }
  }
}
