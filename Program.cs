using StudentManagementSystem;
using System;
using System.Windows.Forms;
using UnicomTIC_SchoolMnagement.Views;
using UnicomTICManagementSystem.Repositories;
using UnicomTICManagementSystem.Views;

namespace UnicomTICManagementSystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DatabaseManager.InitializeDatabase(); // Add this
            Application.Run(new CourseForm()); // or your start form
        }
    }
}
