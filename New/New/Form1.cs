using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using New;

namespace New
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Student> students;

        private void Form1_Load(object sender, EventArgs e)
        {
            // Khởi tạo danh sách học sinh ban đầu
            students = new List<Student>();
            students.Add(new Student() { ID = 1, Name = "A", Age = 20 });
            students.Add(new Student() { ID = 2, Name = "B", Age = 21 });
            students.Add(new Student() { ID = 3, Name = "C", Age = 22 });
            students.Add(new Student() { ID = 4, Name = "D", Age = 23 });
            dtaStudent.DataSource = students;
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtaStudent.DataSource = null;
            dtaStudent.DataSource = students;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dtaStudent.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student to delete.");
                return;
            }

            // Lấy học sinh được chọn và xóa
            var selectedStudent = students[dtaStudent.SelectedRows[0].Index];
            students.Remove(selectedStudent);

            // Cập nhật lại DataGridView hoặc ListBox
            dtaStudent.DataSource = new BindingList<Student>(students);
        }

        private void btn_Add(object sender, EventArgs e)
        {
            try
            {
                int studentID = int.Parse(txtMa.Text);
                string name = txtName.Text;
                int age = int.Parse(txtAge.Text);

                if (students.Any(s => s.ID == studentID))
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                students.Add(new Student
                {
                    ID = studentID,
                    Name = name,
                    Age = age
                });

                
                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnFix_Click(object sender, EventArgs e)
        {
            if (dtaStudent.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student to edit.");
                return;
            }

            // Lấy học sinh được chọn
            var selectedStudent = students[dtaStudent.SelectedRows[0].Index];
            selectedStudent.ID = int.Parse(txtMa.Text);
            selectedStudent.Name = txtName.Text;
            selectedStudent.Age = int.Parse(txtAge.Text);

            // Cập nhật lại DataGridView hoặc ListBox
            dtaStudent.DataSource = new BindingList<Student>(students);
        }
    }
}


