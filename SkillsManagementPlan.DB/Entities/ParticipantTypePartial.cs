using SkillsManagementPlan.Modules.Codes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SkillsManagementPlan.DB.Entities
{
    /// <summary>
    /// Дополнительный класс участников.
    /// </summary>
    public partial class ParticipantType
    {
        /// <summary>
        /// Обработчик преобразования иконки в BitmapImage.
        /// </summary>
        public BitmapImage IconeImage
        {
            get
            {
                return ImageWorker.ByteArrayToImage(this.Icon);
            }
        }
    }
}
