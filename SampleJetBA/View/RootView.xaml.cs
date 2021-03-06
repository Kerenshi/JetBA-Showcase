﻿using Ninject;
using PanelSW.Installer.JetBA.ViewModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace SampleJetBA.View
{
    public partial class RootView : Window
    {
        public RootView(ProgressViewModel prog, PopupViewModel popup, VariablesViewModel vars, NavigationViewModel nav, UtilViewModel util)
        {
            ProgressViewModel = prog;
            PopupViewModel = popup;
            VariablesViewModel = vars;
            NavigationViewModel = nav;
            UtilViewModel = util;

            DataContext = this;
            Closing += RootView_Closing;
            InitializeComponent();
        }

        // Support closing from NavigationViewModel only.
        private void RootView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            NavigationViewModel.StopCommand.Execute(this);
        }

        public ProgressViewModel ProgressViewModel { get; private set; }
        public PopupViewModel PopupViewModel { get; private set; }
        public VariablesViewModel VariablesViewModel { get; private set; }
        public NavigationViewModel NavigationViewModel { get; private set; }
        public UtilViewModel UtilViewModel { get; private set; }

        private void Background_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
