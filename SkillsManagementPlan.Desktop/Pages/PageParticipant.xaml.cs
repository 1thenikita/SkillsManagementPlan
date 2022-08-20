using SkillsManagementPlan.DB.Entities;
using SkillsManagementPlan.Desktop.Classes;
using SkillsManagementPlan.Modules.Codes;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace SkillsManagementPlan.Desktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageParticipant.xaml
    /// </summary>
    public partial class PageParticipant : Page
    {
        private ParticipantType _participant;

        /// <summary>
        /// Инициализация добавления участника.
        /// </summary>
        public PageParticipant()
        {
            InitializeComponent();
            _participant = new ParticipantType();
            DataContext = _participant;
            btnImageDelete.IsEnabled = false;
        }

        /// <summary>
        /// Инициализация изменения участника.
        /// </summary>
        /// <param name="participant"></param>
        public PageParticipant(ParticipantType participant)
        {
            InitializeComponent();
            _participant = participant;
            DataContext = _participant;
            btnImageDelete.IsEnabled = false;
            if (_participant.Icon != null) imgImage.Source = _participant.IconeImage;
        }

        /// <summary>
        /// Обработчик загрузки иконки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImageLoad_Click(object sender, RoutedEventArgs e)
        {
            var fileWorker = new FileWorker("Load icon", "ICO files|*.ICO|JPG files|*.JPG|JPEG files|*.JPEG|PNG files |*.PNG");
            string filePath = fileWorker.GetFilePath();
            if (filePath == null) return;
            _participant.Icon = fileWorker.GetByteArrayFromFile(filePath);
            btnImageDelete.IsEnabled = true;
        }

        /// <summary>
        /// Обработчик удаления иконки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImageDelete_Click(object sender, RoutedEventArgs e)
        {
            _participant.Icon = null;
            imgImage.Source = null;
            btnImageDelete.IsEnabled = false;
        }

        /// <summary>
        /// Обработчик сохранения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (String.IsNullOrWhiteSpace(_participant.Name))
                errors.AppendLine("Write Caption.");
            if(String.IsNullOrWhiteSpace(_participant.Acronym))
                errors.AppendLine("Write Acronym.");
            if (String.IsNullOrWhiteSpace(_participant.Acronym))
                errors.AppendLine("Write Acronym.");

            if (errors.Length != 0)
            {
                MessageBox.Show($@"Elimenate errors.\n{errors.ToString()}", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                if (_participant.ID == 0)
                    Global.DB.ParticipantTypes.Add(_participant);
                Global.DB.SaveChanges();
                MessageBox.Show("Participant succesfully saved!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception error)
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
