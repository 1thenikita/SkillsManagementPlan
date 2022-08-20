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
    /// Логика взаимодействия для PagePlan.xaml
    /// </summary>
    public partial class PagePlan : Page
    {
        private Plan _plan;
        public PagePlan()
        {
            InitializeComponent();
            _plan = new Plan();
            DataContext = _plan;
            try
            {
                cbTimezone.ItemsSource = Global.DB.Timezones.Take(30).ToList();
            }
            catch(Exception e)
            {
                if(Global.WindowModule != null)
                    Global.WindowModule.Close();
            }
        }

        public PagePlan(Plan plan)
        {
            InitializeComponent();
            _plan = plan;
            DataContext = _plan;
            try
            {
                cbTimezone.ItemsSource = Global.DB.Timezones.Take(30).ToList();
            }
            catch (Exception e)
            {
                if (Global.WindowModule != null)
                    Global.WindowModule.Close();
            }
        }

        /// <summary>
        /// Обработчик сохранения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            var errors = new StringBuilder();

            if (String.IsNullOrWhiteSpace(_plan.ChampionshipName))
                errors.AppendLine("Write championship name.");
            if (String.IsNullOrWhiteSpace(_plan.CompetenceName))
                errors.AppendLine("Write competence name.");

            if(errors.Length != 0)
            {
                MessageBox.Show($@"Elimenate errors.\n{errors.ToString()}", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                if (_plan.ID == 0)
                    Global.DB.Plans.Add(_plan);
                Global.DB.SaveChanges();
                MessageBox.Show("Plan succesfully saved!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception error)
            {
                MessageBox.Show($@"Error with saving!\nError: {error.Message}", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Обработчик закрытия страницы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Global.WindowModule.Close();
        }
    }
}
