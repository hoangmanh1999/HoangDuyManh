using Practice_HoangDuyManh.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Contacts;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Practice_HoangDuyManh
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Model.Contact> Contacts;
        private List<Model.Image> Icons;
        public MainPage()
        {
            
            this.InitializeComponent();
            Icons = new List<Model.Image>();
            Icons.Add(new Model.Image { ImagePath = "Assets/MyNews.jpg" });
            Icons.Add(new Model.Image { ImagePath = "Assets/Science.jpg" });
            Icons.Add(new Model.Image { ImagePath = "Assets/Sports.jpg" });
            Icons.Add(new Model.Image { ImagePath = "Assets/Would.jpg" });

            Contacts = new ObservableCollection<Model.Contact>();
        }
        private void NewContactButton_Click(object sender, RoutedEventArgs e)
        {
            string avatar = ((Model.Image)ImageComboBox.SelectedValue).ImagePath;
            Contacts.Add(new Model.Contact { Product = ProductTextBox.Text, Description = DescriptionTextBox.Text, AvatarPath = avatar });

            ProductTextBox.Text = "";
            DescriptionTextBox.Text = "";
            ImageComboBox.SelectedIndex = -1;

            ProductTextBox.Focus(FocusState.Programmatic);
        }
    }
}
