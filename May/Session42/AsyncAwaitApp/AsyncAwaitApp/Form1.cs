using AsyncAwaitApp.Services;
using System.Diagnostics;

namespace AsyncAwaitApp
{
    public partial class Form1 : Form
    {
        private PrintingServices _service = new PrintingServices();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnHello_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello Pressed");
            Debug.WriteLine("Hello Pressed");
        }
        private void btnPrintSync_Click(object sender, EventArgs e)
        {
            _service.Print();
            MessageBox.Show("End of PrintSync");
        }
        private void btnTask_1_Click(object sender, EventArgs e)
        {
            Task.Run(_service.Print);
            MessageBox.Show("End of btnTask");
        }

        private async void btnPrintAsync1_Click(object sender, EventArgs e)
        {
            await _service.PrintAsync1();
            MessageBox.Show("End of PrintAsync1");
        }

        private async void btnPrintAsync2_Click(object sender, EventArgs e)
        {
            var result = await _service.PrintAsync2();
            MessageBox.Show(result.ToString());
        }
    }
}