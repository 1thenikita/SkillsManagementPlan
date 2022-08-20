using SkillsManagementPlan.DB.Models;
using SkillsManagementPlan.Desktop.Classes;
using SkillsManagementPlan.Desktop.Pages;
using SkillsManagementPlan.Desktop.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SkillsManagementPlan.Desktop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Инициализация главного окна.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            CreateInstanceDB();
            Global.FrameMain = this.frmMain;
            Global.FrameMain.Navigate(new PageActivities());
        }

        /// <summary>
        /// Инициализация соеднинения с БД.
        /// </summary>
        private void CreateInstanceDB()
        {
            try
            {
                Global.DB = new DB.Entities.DBEntities();
            }
            catch (Exception e)
            {
                MessageBox.Show($@"Program not working!\nError: {e.Message}\n\nClosing...", "Critical error!", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }

        private void frmMain_ContentRendered(object sender, EventArgs e)
        {

        }

        private void menuItemActivityOpen(object sender, RoutedEventArgs e)
        {
            new ModuleWindow(new PagePlans()).ShowDialog();
            if (frmMain.Content is PageActivities) (frmMain.Content as PageActivities).UpdateDatas();
            tbInfo.DataContext = new Info();
        }

        private void menuAbout(object sender, RoutedEventArgs e)
        {
            new ModuleWindow(new PageInfo()).ShowDialog();
        }
    }
}