using System;
using System.Windows.Forms;

namespace Test.BackgroundThreads
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private readonly ViewModel _viewModel;
        public Form1()
        {
            InitializeComponent();
            _viewModel = new ViewModel();

            InitializeBinding();
            simpleButton1.Click += SimpleButton1_Click;
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            _viewModel.StartBackgroundTask();
        }

        private void InitializeBinding()
        {
            // Bind the counter value to the label
            labelControl1.DataBindings.Add("Text", _viewModel, "Counter", true, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
