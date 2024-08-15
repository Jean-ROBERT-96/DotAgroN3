using Kernel;
using Kernel.Entities;
using Kernel.Filters;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace DotAgroN3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddTab(string header, UserControl content)
        {
            TabItem tabItem = new TabItem();
            StackPanel headerPanel = new StackPanel { Orientation = Orientation.Horizontal };
            TextBlock headerText = new TextBlock { Text = header };
            Button closeButton = new Button { Content = "X", Width = 20, Height = 20, Margin = new Thickness(5, 0, 0, 0) };
            closeButton.Click += (s, e) => CloseTab(tabItem);

            headerPanel.Children.Add(headerText);
            headerPanel.Children.Add(closeButton);

            tabItem.Header = headerPanel;
            tabItem.Content = content;
            tabControl.Items.Add(tabItem);
            tabControl.SelectedItem = tabItem;
        }

        private void CloseTab(TabItem tabItem)
        {
            tabControl.Items.Remove(tabItem);
        }
    }
}