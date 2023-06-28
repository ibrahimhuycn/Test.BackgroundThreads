using System;
using System.Threading;

namespace Test.BackgroundThreads
{

    public class ViewModel: NotifyBase
    {
        // Define a delegate for the callback method
        delegate void BackgroundUiUpdateDelegate(int value);
        BackgroundUiUpdateDelegate _backgroundUiUpdateDelegate;
        private string _counter;

        public string Counter
        {
            get => _counter; set
            {
                _counter = value;
                OnPropertyChanged();
            }
        }


        public void StartBackgroundTask()
        {
            // Assign the callback method to the delegate
            _backgroundUiUpdateDelegate = UiUpdatesFromBackgroundTaskBubbledUpToUiThread;

            // Start a new thread for the background task
            Thread backgroundThread = new Thread(BackgroundTask);
            backgroundThread.Start();
        }

        private void BackgroundTask()
        {
            // Perform background task logic here
            for (int i = 0; i < 100; i++)
            {

                // Invoke the callback method. This can be invoked after processing is completed too.
                _backgroundUiUpdateDelegate.Invoke(i);

                Thread.Sleep(10);
            }
        }



        // Callback method, on UI thread
        private void UiUpdatesFromBackgroundTaskBubbledUpToUiThread(int value)
        {
            Counter = $"{value}%";
            if(value == 99) { Counter = "Done"; }
        }
    }
}
