using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsManagementPlan.Modules.Codes
{
    public class FileWorker
    {
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;

        public FileWorker(string title, string fileTypes)
        {
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            openFileDialog.Title = saveFileDialog.Title = title;
            openFileDialog.Filter = saveFileDialog.Filter = fileTypes;
        }

        public bool FileExist(string filePath)
        {
            return File.Exists(filePath);
        }

        public string GetFilePath()
        {
            var status = openFileDialog.ShowDialog();
            if (status == null || status == false) return null;

            if (File.Exists(openFileDialog.FileName)) return openFileDialog.FileName;
            return null;
        }

        public byte[] GetByteArrayFromFile(string filePath)
        {
            if (!this.FileExist(filePath)) return null;
            try
            {
                return File.ReadAllBytes(filePath);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public string[] GetTextFromFile(string filePath)
        {
            if (!this.FileExist(filePath)) return null;
            try
            {
                return File.ReadAllLines(filePath);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool SaveTextToFile(string filePath, string text)
        {
            try
            {
                File.WriteAllText(filePath, text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SaveByteArrayToFile(string filePath, byte[] byteArray)
        {
            try
            {
                File.WriteAllBytes(filePath, byteArray);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
