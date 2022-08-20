using SkillsManagementPlan.DB.Entities;
using SkillsManagementPlan.Desktop.Classes;
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
    /// Логика взаимодействия для PagePlans.xaml
    /// </summary>
    public partial class PagePlans : Page
    {
        /// <summary>
        /// Инициализация страницы.
        /// </summary>
        public PagePlans()
        {
            InitializeComponent();
            UpdateDatas();
        }

        /// <summary>
        /// Обработчик обновления данных.
        /// </summary>
        private void UpdateDatas()
        {
            try
            {
                lvPlans.ItemsSource = Global.DB.Plans.ToList();
            }
            catch
            {
                Global.WindowModule.Close();
            }
        }

        /// <summary>
        /// Обработчик поиска.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbSearch.Text))
            {
                UpdateDatas(); return;
            }
            try
            {
                lvPlans.ItemsSource = Global.DB.Plans.Where(p => p.ChampionshipName.ToLower().Contains(tbSearch.Text.ToLower())).ToList();
            }
            catch
            {
                Global.WindowModule.Close();
            }
        }

        /// <summary>
        /// Обработчик добавления записи.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Global.WindowModule.FrameModule.Navigate(new PagePlan());
        }

        /// <summary>
        /// Обработчик изменения записи.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var plan = lvPlans.SelectedItem as Plan;
            if (plan == null) return;

            Global.WindowModule.FrameModule.Navigate(new PagePlan(plan));
            UpdateDatas();
        }

        /// <summary>
        /// Обработчик удаления записи.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var plans = lvPlans.SelectedItems.Cast<Plan>().ToList();
            if (plans.Count == 0) return;

            MessageBoxResult result = MessageBox.Show($@"Are you sure want to delete {plans.Count} entries?", "Confirm delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) return;

            try
            {
                Global.DB.Plans.RemoveRange(plans);
                Global.DB.SaveChanges();
                MessageBox.Show($@"Successfully deleted {plans.Count} entries!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateDatas();
            }
            catch
            {
                Global.WindowModule.Close();
            }
        }

        /// <summary>
        /// Обработчик закрытия окна.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Global.WindowModule.Close();
        }

        /// <summary>
        /// Обработчик выбора сущности.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            var plan = lvPlans.SelectedItem as Plan;
            if (plan == null) return;
            Global.CurrentPlan = plan;
            Global.WindowModule.Close();
        }
    }
}
