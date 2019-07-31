﻿using System;
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
using Microsoft.VisualBasic;

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
        // Ask user what to do with source files
        MsgBoxResult promptRes = Interaction.MsgBox("Сохранить исходные файлы?", MsgBoxStyle.YesNoCancel, this.Title);
        bool preserveSrc;
        switch (promptRes)
        {
          case MsgBoxResult.Yes:
            preserveSrc = true;
            break;
          case MsgBoxResult.No:
            preserveSrc = true;
            break;
          default:
            return;
        }
        
        string userMessage;
        // Get the list of files
        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
        // Process every file
        string[] filesFixed = ExtensionFixer.FixFiles(files, preserveSrc);
        switch (filesFixed.Length)
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
