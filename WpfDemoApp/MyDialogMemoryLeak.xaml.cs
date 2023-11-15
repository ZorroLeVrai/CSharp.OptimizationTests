using System;
using System.Windows;

namespace WpfDemoApp
{
    /// <summary>
    /// Interaction logic for MyDialog.xaml
    /// </summary>
    public partial class MyDialogMemoryLeak : Window
    {
        private int[] items;
        private FakePublisher? _fakePublisher;

        public MyDialogMemoryLeak()
        {
            InitializeComponent();

            items = new int[10_000_000];
        }

        public void SubscribeFakePublisher(FakePublisher publisher)
        {
            _fakePublisher = publisher;
            _fakePublisher.PublishEvent += EventPublished;
        }

        public void EventPublished(object? sender, EventArgs e)
        {

        }

        private void OnClose(object sender, EventArgs e)
        {
            //_fakePublisher.PublishEvent -= EventPublished;
        }
    }
}
