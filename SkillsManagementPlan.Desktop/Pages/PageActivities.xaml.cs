using SkillsManagementPlan.DB.Entities;
using SkillsManagementPlan.Desktop.Classes;
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

namespace SkillsManagementPlan.Desktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageActivities.xaml
    /// </summary>
    public partial class PageActivities : Page
    {
        /// <summary>
        /// Инициализация страницы.
        /// </summary>
        public PageActivities()
        {
            InitializeComponent();
            UpdateDatas();
        }

        /// <summary>
        /// Обработчик обновления данных.
        /// </summary>
        public void UpdateDatas()
        {
            try
            {
                if (Global.CurrentPlan == null)
                    dgActivities.ItemsSource = Global.DB.Activities.OrderByDescending(a => a.DateTimeStart).ToList();
                else
                    dgActivities.ItemsSource = Global.DB.Activities.OrderByDescending(a => a.DateTimeStart).Where(a => a.Plan.ID == Global.CurrentPlan.ID).ToList();
            }
            catch(Exception ex)
            {
                Global.FrameMain.GoBack();
            }
        }

        /// <summary>
        /// Обработчик создания нового плана.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewPlan_Click(object sender, RoutedEventArgs e)
        {
            new ModuleWindow(new PagePlan()).ShowDialog();
        }

        /// <summary>
        /// Обработчик сохранения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Обработчик импорта данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Обработчик экспорта данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Обработчик добавления активности.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            new ModuleWindow(new PageActivity()).ShowDialog();
            UpdateDatas();
        }

        /// <summary>
        /// Обработчик удаления актовности.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var activities = dgActivities.SelectedItems.Cast<Plan>().ToList();
            if (activities.Count == 0) return;

            MessageBoxResult result = MessageBox.Show($@"Are you sure want to delete {activities.Count} entries?", "Confirm delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) return;

            try
            {
                Global.DB.Plans.RemoveRange(activities);
                Global.DB.SaveChanges();
                MessageBox.Show($@"Successfully deleted {activities.Count} entries!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateDatas();
            }
            catch
            {
                Global.WindowModule.Close();
            }
        }
        
        /// <summary>
        /// Обработчик печати.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Обработчик поднятия вверх.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Обработчик опускания вниз.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Обработчик открытия справочника.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Обработчик обновления.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateDatas();
        }
    }
}
