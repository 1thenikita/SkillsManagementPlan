using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsManagementPlan.DB.Entities
{
    /// <summary>
    /// Дополнительный класс мероприятий.
    /// </summary>
    public partial class Activity
    {
        /// <summary>
        /// Обработчик преобразования участников в строковый вид.
        /// </summary>
        public string ParticipantTypesToString
        {
            get
            {
                string res = "";
                foreach(var participant in ParticipantTypes)
                {
                    res += participant.Name + ", ";
                }
                return res;
            }
        }

        /// <summary>
        /// Обработчик преобразования времени в строковый вид.
        /// </summary>
        public string TimeToString
        {
            get
            {
                string res = "";
                res += this.DateTimeStart.ToString("hh:MM");
                res += " - ";
                res += this.DateTimeEnd.ToString("hh:MM");
                res += $@" ({(this.DateTimeEnd - this.DateTimeStart).ToString("hh:MM")})";

                return res;
            }
        }
    }
}
