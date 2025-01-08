using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Question1
{
    public partial class MainWindow : Window
    {
        private string connectionString = "Data Source=KHUZAIM-PC;Initial Catalog=master;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public MainWindow()
        {
            InitializeComponent();
            LoadStudents();
            LoadFilters();
        }

        private void LoadStudents()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT Name, Grade, Subject, Marks, AttendancePercentage FROM Stu", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                StudentsDataGrid.ItemsSource = dataTable.DefaultView;
            }
        }

        private void LoadFilters()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand gradeCommand = new SqlCommand("SELECT DISTINCT Grade FROM Stu", connection);
                SqlDataReader gradeReader = gradeCommand.ExecuteReader();
                while (gradeReader.Read())
                {
                    GradeFilterComboBox.Items.Add(gradeReader["Grade"].ToString());
                }
                gradeReader.Close();

                SqlCommand subjectCommand = new SqlCommand("SELECT DISTINCT Subject FROM Stu", connection);
                SqlDataReader subjectReader = subjectCommand.ExecuteReader();
                while (subjectReader.Read())
                {
                    SubjectFilterComboBox.Items.Add(subjectReader["Subject"].ToString());
                }
                subjectReader.Close();
            }
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Stu (Name, Grade, Subject, Marks, AttendancePercentage) VALUES (@Name, @Grade, @Subject, @Marks, @Attendance)", connection);
                command.Parameters.AddWithValue("@Name", NameTextBox.Text);
                command.Parameters.AddWithValue("@Grade", GradeTextBox.Text);
                command.Parameters.AddWithValue("@Subject", SubjectTextBox.Text);
                command.Parameters.AddWithValue("@Marks", int.Parse(MarksTextBox.Text));
                command.Parameters.AddWithValue("@Attendance", decimal.Parse(AttendanceTextBox.Text));

                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Student added successfully.");
                LoadStudents();
            }
        }

        private void EditStudent_Click(object sender, RoutedEventArgs e)
        {
            if (StudentsDataGrid.SelectedItem != null)
            {
                DataRowView row = (DataRowView)StudentsDataGrid.SelectedItem;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("UPDATE Stu SET Name=@Name, Grade=@Grade, Subject=@Subject, Marks=@Marks, AttendancePercentage=@Attendance WHERE Name=@Name", connection);
                    command.Parameters.AddWithValue("@Name", NameTextBox.Text);
                    command.Parameters.AddWithValue("@Grade", GradeTextBox.Text);
                    command.Parameters.AddWithValue("@Subject", SubjectTextBox.Text);
                    command.Parameters.AddWithValue("@Marks", int.Parse(MarksTextBox.Text));
                    command.Parameters.AddWithValue("@Attendance", decimal.Parse(AttendanceTextBox.Text));

                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Student updated successfully.");
                    LoadStudents();
                }
            }
            else
            {
                MessageBox.Show("Please select a student to edit.");
            }
        }

        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            if (StudentsDataGrid.SelectedItem != null)
            {
                DataRowView row = (DataRowView)StudentsDataGrid.SelectedItem;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("DELETE FROM Stu WHERE Name=@Name", connection);
                    command.Parameters.AddWithValue("@Name", row["Name"]);

                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Student deleted successfully.");
                    LoadStudents();
                }
            }
            else
            {
                MessageBox.Show("Please select a student to delete.");
            }
        }

        private void ApplyFilters_Click(object sender, RoutedEventArgs e)
        {
            string gradeFilter = GradeFilterComboBox.SelectedItem?.ToString();
            string subjectFilter = SubjectFilterComboBox.SelectedItem?.ToString();

            string query = "SELECT Name, Grade, Subject, Marks, AttendancePercentage FROM Stu WHERE 1=1";
            if (!string.IsNullOrEmpty(gradeFilter))
            {
                query += " AND Grade = @Grade";
            }
            if (!string.IsNullOrEmpty(subjectFilter))
            {
                query += " AND Subject = @Subject";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                if (!string.IsNullOrEmpty(gradeFilter))
                {
                    command.Parameters.AddWithValue("@Grade", gradeFilter);
                }
                if (!string.IsNullOrEmpty(subjectFilter))
                {
                    command.Parameters.AddWithValue("@Subject", subjectFilter);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                StudentsDataGrid.ItemsSource = dataTable.DefaultView;
            }
        }
    }
}
