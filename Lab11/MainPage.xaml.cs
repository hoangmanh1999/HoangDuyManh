﻿using Lab11.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using static Lab11.Model.Sound;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Lab11
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Sound> sounds;
        private List<String> Suggestions;
        private List<MenuItem> menuItems;
        public MainPage()
        {
            this.InitializeComponent();
            sounds = new ObservableCollection<Sound>();
            SoundManager.GetAllSounds(sounds);
            menuItems = new List<MenuItem>();
            menuItems.Add(new MenuItem { IconFile = "Assets/Icons/animals.png", Category = SoundCategory.Animals });
            menuItems.Add(new MenuItem { IconFile = "Assets/Icons/cartoon.png", Category = SoundCategory.Cartoons });
            menuItems.Add(new MenuItem { IconFile = "Assets/Icons/taunt.png", Category = SoundCategory.Taunts });
            menuItems.Add(new MenuItem { IconFile = "Assets/Icons/warning.png", Category = SoundCategory.Warnings });
            BackButton.Visibility = Visibility.Collapsed;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Goback();
        }

        private void SearchAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            SoundManager.GetAllSounds(sounds);
            Suggestions = sounds.Where(p => p.Name.StartsWith(sender.Text)).Select(p => p.Name).ToList();
            SearchAutoSuggestBox.ItemsSource = Suggestions;
            if (String.IsNullOrEmpty(sender.Text))
                Goback();
        }

        private void SearchAutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            SoundManager.GetSoundByName(sounds, sender.Text);
            CategoryTextBlock.Text = sender.Text;
            MenuItemsListView.SelectedItem = null;
            BackButton.Visibility = Visibility.Visible;
        }

        private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem)e.ClickedItem;

            CategoryTextBlock.Text = menuItem.Category.ToString();
            SoundManager.GetSoundsByCategory(sounds, menuItem.Category);
            BackButton.Visibility = Visibility.Visible;
        }

        private void SoundGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sounds = (Sound)e.ClickedItem;
            MyMediaElement.Source = new Uri(this.BaseUri, sounds.AudioFile);

        }

        private async void SoundGridView_Drop(object sender, DragEventArgs e)
        {
            if(e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var items = await e.DataView.GetStorageItemsAsync();
                if (items.Any())
                {
                    var storageFile = items[0] as StorageFile;
                    var contentType = storageFile.ContentType;

                    StorageFolder folder = ApplicationData.Current.LocalFolder;

                    if(contentType=="audio/wav" || contentType == "audio/mpeg")
                    {
                        StorageFile newFile = await storageFile.CopyAsync(folder, storageFile.Name, NameCollisionOption.GenerateUniqueName);
                        MyMediaElement.SetSource(await storageFile.OpenAsync(FileAccessMode.Read), contentType);
                        MyMediaElement.Play();
                    }
                }
            }
        }

        private void SoundGridView_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;
            e.DragUIOverride.Caption = "drop to create a  custom sound and tilte";
            e.DragUIOverride.IsCaptionVisible = true;
            e.DragUIOverride.IsContentVisible = true;
            e.DragUIOverride.IsGlyphVisible = true;
        }

        private void Goback()
        {
            SoundManager.GetAllSounds(sounds);
            CategoryTextBlock.Text = "All Sounds";
            MenuItemsListView.SelectedItem = null;
            BackButton.Visibility = Visibility.Collapsed;
         }
    }
}
