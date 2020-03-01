using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Dokumentaci k šabloně položky Prázdná stránka najdete na adrese https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x405

namespace eXclusiveMediaFormatter
{
    /// <summary>
    /// Prázdná stránka, která se dá použít samostatně nebo v rámci objektu Frame
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private int radioButtonSelection;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Progress_Changed(object sender, RangeBaseValueChangedEventArgs e)
        {

        }

        private void SourceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DestinationTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender == BrowseButtonSource)
            {
                createMusicFileOpenPicker();
            }
            else
            {
                createFolderFileOpenPicker();
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (Mp3Radio.IsChecked.Value)
            {
                radioButtonSelection = 0;
            }
            else if(WavRad.IsChecked.Value)
            {
                radioButtonSelection = 1;
            }
            else if(FlacRad.IsChecked.Value)
            {
                radioButtonSelection = 2;
            }
            else if(OggRad.IsChecked.Value)
            {
                radioButtonSelection = 3;
            }
            else
            {
                radioButtonSelection = 4;
            }
        }

        private async void createMusicFileOpenPicker()
        {
            var musicPicker = new Windows.Storage.Pickers.FileOpenPicker();
            musicPicker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            musicPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.MusicLibrary;
            musicPicker.FileTypeFilter.Add(".mp3");
            musicPicker.FileTypeFilter.Add(".flac");
            musicPicker.FileTypeFilter.Add(".ogg");
            musicPicker.FileTypeFilter.Add(".wave");
            musicPicker.FileTypeFilter.Add("*");

            Windows.Storage.StorageFile file = await musicPicker.PickSingleFileAsync();
            if (file != null)
            {
                SourceTextBox.Text = file.Path;
            }
            else
            {
                SourceTextBox.Text = "Operation cancelled.";
            }
        }

        private async void createFolderFileOpenPicker()
        {
            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add("*");

            Windows.Storage.StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                Windows.Storage.AccessCache.StorageApplicationPermissions.
                FutureAccessList.AddOrReplace("PickedFolderToken", folder);
                DestinationTextBox.Text = folder.Path;
            }
            else
            {
                DestinationTextBox.Text = "Operation cancelled.";
            }
        }
    }
}
