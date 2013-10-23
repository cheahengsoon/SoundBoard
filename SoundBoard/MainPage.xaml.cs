﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SoundBoard.Resources;
using SoundBoard.ViewModels;
using Coding4Fun.Toolkit.Controls;

namespace SoundBoard
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;

            // Sample code to localize the ApplicationBar
            BuildLocalizedApplicationBar();
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void LongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LongListSelector selector = sender as LongListSelector;
            //verifying our sender is actually a LongListSelector
            if (selector == null)
                return;

            SoundData data = selector.SelectedItem as SoundData;
            //verifying our sender is actually SoundData
            if (data == null)
                return;

            AudioPlayer.Source = new Uri(data.FilePath, UriKind.RelativeOrAbsolute);

            selector.SelectedItem = null;
        }

        // Sample code for building a localized ApplicationBar
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton recordAudioAppBar = new ApplicationBarIconButton();
            recordAudioAppBar.IconUri = new Uri("/Assets/AppBar/microphone.png", UriKind.Relative);

            recordAudioAppBar.Text = AppResources.AppBarRecord;
            recordAudioAppBar.Click += recordAudioAppBar_Click;
            ApplicationBar.Buttons.Add(recordAudioAppBar);

            // Create a new menu item with the localized string from AppResources.
            ApplicationBarMenuItem aboutAppBar = new ApplicationBarMenuItem();
            aboutAppBar.Text = AppResources.AppBarAbout;
            aboutAppBar.Click += aboutAppBar_Click;
            ApplicationBar.MenuItems.Add(aboutAppBar);
        }

        void aboutAppBar_Click(object sender, EventArgs e)
        {
            AboutPrompt aboutMe= new AboutPrompt();
            aboutMe.Show("DYDYD", null, "njlxyaoxinwei@msn.cn");
        }

        void recordAudioAppBar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}