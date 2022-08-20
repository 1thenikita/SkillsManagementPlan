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
    /// Логика взаимодействия для PageParticipants.xaml
    /// </summary>
    public partial class PageParticipants : Page
    {
        /// <summary>
        /// Инициализация страницы.
        /// </summary>
        public PageParticipants()
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
                lvParticipants.ItemsSource = Global.DB.ParticipantTypes.ToList();
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
                lvParticipants.ItemsSource = Global.DB.ParticipantTypes.Where(p => p.Name.ToLower().Contains(tbSearch.Text.ToLower())).ToList();
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
            Global.WindowModule.FrameModule.Navigate(new PageParticipant());
        }

        /// <summary>
        /// Обработчик изменения записи.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var participant = lvParticipants.SelectedItem as ParticipantType;
            if (participant == null) return;

            Global.WindowModule.FrameModule.Navigate(new PageParticipant(participant));
            UpdateDatas();
        }
        
        /// <summary>
        /// Обработчик удаления записи.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var participants = lvParticipants.SelectedItems.Cast<ParticipantType>().ToList();
            if (participants.Count == 0) return;

            MessageBoxResult result = MessageBox.Show($@"Are you sure want to delete {participants.Count} entries?", "Confirm delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) return;

            try
            {
                Global.DB.ParticipantTypes.RemoveRange(participants);
                Global.DB.SaveChanges();
                MessageBox.Show($@"Successfully deleted {participants.Count} entries!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
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
    }
}
