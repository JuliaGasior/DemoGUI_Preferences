using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace DemoGUI_Preferences
{
    /// <summary>
    /// Logika interakcji dla klasy Calendar.xaml
    /// </summary>
    public partial class Calendar : Window
    {
        public DateTime? SelectedDateValue { get; private set; }

        public Calendar()
        {
            InitializeComponent();
        }

        private void DateCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedDateValue = DateCalendar.SelectedDate;
            DialogResult = true;
        }
    }
}
