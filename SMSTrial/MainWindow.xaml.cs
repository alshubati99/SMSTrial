using Microsoft.EntityFrameworkCore;
using SMSTrial.EntityModel;
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

namespace SMSTrial
{
    public partial class MainWindow : Window
    {
        private StudentsContext context; // Declare StudentsContext as a field in the MainWindow class
        private student_tbl result; // Declare the result as a field

        public MainWindow()
        {
            InitializeComponent();

            var options = new DbContextOptionsBuilder<StudentsContext>().UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=SSMS;Integrated Security=True; TrustServerCertificate=True").Options;
            context = new StudentsContext(options);
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            student_tbl tbleobj = new student_tbl(); // Move the instantiation of student_tbl inside the event handler

            tbleobj.id = int.Parse(text_id.Text);
            tbleobj.fname = text_fname.Text;
            tbleobj.lname = text_lname.Text;
            tbleobj.department = text_dep.Text;

            context.student_tbls.Add(tbleobj); // Add the tbleobj to the student_tbls DbSet
            context.SaveChanges(); // Save the changes to persist the data
            ClearControl();
            LoadGrid();
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(text_id.Text);
            result = context.student_tbls.Find(id); // Use Find method to retrieve the entity by its primary key
            if (result != null)
            {
                text_fname.Text = result.fname;
                text_lname.Text = result.lname;
                text_dep.Text = result.department;
            }
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            if (result != null)
            {
                result.fname = text_fname.Text;
                result.lname = text_lname.Text;
                result.department = text_dep.Text;

                context.SaveChanges();
                context.student_tbls.Add(result);
                ClearControl();
                LoadGrid();
            }
        }

        private void ClearControl()
        {
            text_id.Clear();
            text_fname.Clear();
            text_lname.Clear();
            text_dep.Clear();
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            ClearControl();
        }

        private void LoadGrid()
        {
            var data = from x in context.student_tbls select x;
            dataGrid.ItemsSource = data.ToList();
        }

        private void cb_save_Checked(object sender, RoutedEventArgs e)
        {
            LoadGrid();
        }

        private void cb_save_Unchecked(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Implement the logic for handling dataGrid selection change event if needed
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(text_id.Text);
            var d = context.student_tbls.Single(u => u.id == id);
            context.student_tbls.Remove(d);
            context.SaveChanges();
            ClearControl();
            LoadGrid();

        }

       /* private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            LoadGrid();
        }*/
    }
}
