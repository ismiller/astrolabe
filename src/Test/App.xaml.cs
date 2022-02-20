﻿using Astrolabe.AppSDK;
using Astrolabe.AppSDK.Extensions;
using Astrolabe.Core;
using Microsoft.UI.Xaml;

namespace Test
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            NavigationBuilder.DefaultBuilder
                .UseAppSdkPlatform()
                .UseConfigure<Configure>()
                .Build()
                .Run();
        }

        private Window m_window;
    }
}