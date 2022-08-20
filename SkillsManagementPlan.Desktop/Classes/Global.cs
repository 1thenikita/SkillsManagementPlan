using SkillsManagementPlan.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SkillsManagementPlan.Desktop.Windows;

namespace SkillsManagementPlan.Desktop.Classes
{
    public static class Global
    {
        public static Frame FrameMain { get; set; }
        public static ModuleWindow WindowModule { get; set; }
        public static DBEntities DB { get; set; }

        public static Plan CurrentPlan { get; set; }

    }
}
