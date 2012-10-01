//-------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="Artur Philibin E Silva">
// Copyright (c) Artur Philibin E Silva, All rights reserved.
// </copyright>
//-------------------------------------------------------------------------

namespace DublinBusWindowsPhone
{
    using System.Windows;
    using System.Windows.Navigation;

    using Microsoft.Phone.Controls;
    using Microsoft.Phone.Shell;

    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class
        /// </summary>
        public App()
        {
            // Global handler for uncaught exceptions. 
            this.UnhandledException += this.ApplicationUnhandledException;

            // Standard Silverlight initialization
            this.InitializeComponent();

            // Phone-specific initialization
            this.InitializePhoneApplication();

            // Show graphics profiling information while debugging.
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Display the current frame rate counters.
                Application.Current.Host.Settings.EnableFrameRateCounter = true;

                // Show the areas of the app that are being redrawn in each frame.
                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Enable non-production analysis visualization mode, 
                // which shows areas of a page that are handed off to GPU with a colored overlay.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;

                // Disable the application idle detection by setting the UserIdleDetectionMode property of the
                // application's PhoneApplicationService object to Disabled.
                // Caution:- Use this under debug mode only. Application that disables user idle detection will continue to run
                // and consume battery power when the user is not using the phone.
                PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            }

        }

        /// <summary>
        /// Gets access to the root frame of the Phone Application.
        /// </summary>
        /// <returns>The root frame of the Phone Application.</returns>
        public PhoneApplicationFrame RootFrame { get; private set; }

        // Code to execute when the application is launching (eg, from Start)
        // This code will not execute when the application is reactivated
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        private void ApplicationLaunching(object sender, LaunchingEventArgs e)
        {
        }

        // Code to execute when the application is activated (brought to foreground)
        // This code will not execute when the application is first launched
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        private void ApplicationActivated(object sender, ActivatedEventArgs e)
        {
        }

        // Code to execute when the application is deactivated (sent to background)
        // This code will not execute when the application is closing
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        private void ApplicationDeactivated(object sender, DeactivatedEventArgs e)
        {
        }

        // Code to execute when the application is closing (eg, user hit Back)
        // This code will not execute when the application is deactivated
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        private void ApplicationClosing(object sender, ClosingEventArgs e)
        {
        }

        // Code to execute if a navigation fails
        private void RootFrameNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // A navigation has failed; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        // Code to execute on Unhandled Exceptions
        private void ApplicationUnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        // Avoid double-initialization
        private bool phoneApplicationInitialized = false;

        // Do not add any additional code to this method
        private void InitializePhoneApplication()
        {
            if (this.phoneApplicationInitialized)
            {
                return;
            }

            // Create the frame but don't set it as RootVisual yet; this allows the splash
            // screen to remain active until the application is ready to render.
            this.RootFrame = new PhoneApplicationFrame();
            this.RootFrame.Navigated += this.CompleteInitializePhoneApplication;

            // Handle navigation failures
            this.RootFrame.NavigationFailed += this.RootFrameNavigationFailed;

            // Ensure we don't initialize again
            this.phoneApplicationInitialized = true;
        }

        // Do not add any additional code to this method
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            // Set the root visual to allow the application to render
            if (this.RootVisual != this.RootFrame)
            {
                this.RootVisual = this.RootFrame;
            }

            // Remove this handler since it is no longer needed
            this.RootFrame.Navigated -= this.CompleteInitializePhoneApplication;
        }
    }
}