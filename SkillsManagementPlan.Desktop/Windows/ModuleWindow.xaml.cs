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
using System.Windows.Shapes;

namespace SkillsManagementPlan.Desktop.Windows
{
    /// <summary>
    /// Логика взаимодействия для ModuleWindow.xaml
    /// </summary>
    public partial class ModuleWindow : Window
    {
        /// <summary>
        /// Инициализация модального окна.
        /// </summary>
        /// <param name="page"></param>
        public ModuleWindow(Page page)
        {
            InitializeComponent();
            DataContext = page;
            this.frmModule.Navigate(page);
            Global.WindowModule = this;
        }

        /// <summary>
        /// Обработчик закрытия окна/возврата на предыдущую страницу.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(frmModule.CanGoBack)
            {
                frmModule.GoBack();
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Обработчик закрытия окна в случае отсутсвия возврата назад.
        /// </summary>
        public void GoBackOrClose()
        {
            if (!frmModule.CanGoBack)
                this.Close();
        }

        /// <summary>
        /// Обработчик обновления содержимого окна.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmModule_ContentRendered(object sender, EventArgs e)
        {
            var page= frmModule.DataContext as Page;
            Title = page.Title;
            DataContext = page;
        }
    }
}
