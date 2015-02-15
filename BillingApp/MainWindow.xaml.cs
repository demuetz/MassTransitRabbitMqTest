using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BillingDomain;
using BillingPublisher;

namespace BillingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DomainMessageBus _domainMessageBus = new DomainMessageBus();

        public MainWindow()
        {
            InitializeComponent();

            _domainMessageBus.Start();
        }

        protected override void OnClosed(EventArgs e)
        {
            _domainMessageBus.Stop();
        }

        private void CreateButton_OnClick(object sender, RoutedEventArgs e)
        {
            var count = Convert.ToInt32(BillCountTextBox.Text);

            var command = new CreateBillCommand {};

            for (int i = 0; i < count; i++)
            {
                _domainMessageBus.Publish(command);
            }
        }
    }
}
