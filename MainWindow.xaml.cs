using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoGUI_Preferences;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Preferences p;
    private MenuItem selectedSortingItem;
    private MenuItem selectedTripItem;
    private MenuItem selectedWebsite;
    private MenuItem selectedLocalization;
    public MainWindow()
    {
        InitializeComponent();
        p = new Preferences();
        BookingWebsite b1 = new BookingWebsite();
        b1.Name = "Booking.com";
        BookingWebsite b2 = new BookingWebsite();
        b2.Name = "Airbnb";
        p.website.Add(b1);
        p.website.Add(b2);
        p.Localization.Add(new Localization("Crakow", "Poland"));
        p.Localization.Add(new Localization("Warsaw", "Poland"));
        BuildMenu();
    }
    private void Close_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void NumberOfAdults_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
             if (int.TryParse(NumberOfAdults.Text, out int result))
             {
                p.NumberOfAdults = result;
             }
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message);
        }

    }
    private void NumberOfChildren_TextChanged(object sender, TextChangedEventArgs e)
    {
        try 
        { 
            if (int.TryParse(NumberOfChildren.Text, out int result))
            {
                p.NumberOfChildren = result;
            }
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message);
        }

    }

    private void ButtonArrivalDate_Click(object sender, RoutedEventArgs e)
    {
        var calendarWindow = new Calendar();
        if (calendarWindow.ShowDialog() == true)
        {
            try
            {
                p.ArrivalDate = calendarWindow.SelectedDateValue.Value;
                ButtonArrivalDate.Content = p.ArrivalDate.ToString("dd.MM.yyyy");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    private void ButtonDepartureDate_Click(object sender, RoutedEventArgs e)
    {
        var calendarWindow = new Calendar();
        if (calendarWindow.ShowDialog() == true)
        {
            try
            {
                p.DepartureDate = calendarWindow.SelectedDateValue.Value;
                ButtonDepartureDate.Content = p.DepartureDate.ToString("dd.MM.yyyy");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    private void BuildMenu()
    {
        Filter.Items.Add(CreateEnumMenu("SortingPrice", typeof(SortingPrice), OnSortingClick));
        Filter.Items.Add(CreateEnumMenu("TripType", typeof(TripType), OnTripClick));
        Filter.Items.Add(CreateListMenu("Website", p.website.Select(x => x.Name).ToList(), OnWebsiteClick));
        Filter.Items.Add(CreateListMenu("Localization", p.Localization.Select(x => x.ToString()).ToList(), OnLocalizationClick));
    }
    private MenuItem CreateEnumMenu(string header, Type enumType, RoutedEventHandler handler)
    {
        var parent = new MenuItem { Header = header };
        foreach (var value in Enum.GetValues(enumType))
        {
            var item = new MenuItem
            {
                Header = value.ToString(),
                Tag = value,
                IsCheckable = true
            };

            item.Click += handler;
            parent.Items.Add(item);
        }
        return parent;
    }
    private MenuItem CreateListMenu(string header, List<string> items, RoutedEventHandler handler)
    {
        var parent = new MenuItem { Header = header };

        foreach (var value in items)
        {
            var item = new MenuItem
            {
                Header = value,
                Tag = value,
                IsCheckable = true
            };

            item.Click += handler;
            parent.Items.Add(item);
        }

        return parent;
    }
    private void OnSortingClick(object sender, RoutedEventArgs e)
    {
        var clicked = (MenuItem)sender;
        foreach (MenuItem item in ((MenuItem)Filter.Items[0]).Items)
            item.IsChecked = false;
        clicked.IsChecked = true;
        selectedSortingItem = clicked;
        var value = (SortingPrice)clicked.Tag;
    }
    private void OnTripClick(object sender, RoutedEventArgs e)
    {
        var clicked = (MenuItem)sender;
        foreach (MenuItem item in ((MenuItem)Filter.Items[1]).Items)
            item.IsChecked = false;
        clicked.IsChecked = true;
        selectedTripItem = clicked;
        var value = (TripType)clicked.Tag;
    }
    private void OnWebsiteClick(object sender, RoutedEventArgs e)
    {
        var clicked = (MenuItem)sender;
        foreach (MenuItem item in ((MenuItem)Filter.Items[2]).Items)
            item.IsChecked = false;
        clicked.IsChecked = true;
        selectedWebsite = clicked;
    }
    private void OnLocalizationClick(object sender, RoutedEventArgs e)
    {
        var clicked = (MenuItem)sender;
        foreach (MenuItem item in ((MenuItem)Filter.Items[3]).Items)
            item.IsChecked = false;
        clicked.IsChecked = true;
        selectedLocalization = clicked;
    }
}