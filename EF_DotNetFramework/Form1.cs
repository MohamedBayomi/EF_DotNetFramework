﻿using EF_DotNetFramework.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace EF_DotNetFramework
{
    public partial class Form1 : Form
    {
        private AppDBContext appDBContext;

        public Form1()
        {
            InitializeComponent();

            appDBContext = new AppDBContext();

            var departments = appDBContext.Departments.ToList();

            foreach (Department s in departments)
            {
                cboDepartment.Items.Add(s);
            }

            refreshGrid();
        }

        private void refreshGrid()
        {
            BindingSource bs = new BindingSource();


            var query = from t in appDBContext.Employees
                        orderby t.HireDate
                        select new { t.ID, EmployeeName = t.Name, DepartmentName = t.Department.Name, t.HireDate };

            bs.DataSource = query.ToList();

            dataGridView1.DataSource = bs;
            dataGridView1.Refresh();
        }

        private void cmdCreateEmployee_Click(object sender, EventArgs e)
        {
            if (cboDepartment.SelectedItem != null && txtEmployee.Text != string.Empty)
            {
                var newEmployee = new Employee
                {
                    Name = txtEmployee.Text,
                    DepartmentID = (cboDepartment.SelectedItem as Department).ID,
                    HireDate = dateTimePicker1.Value
                };

                appDBContext.Employees.Add(newEmployee);

                appDBContext.SaveChanges();
                refreshGrid();

                cmdUpdateEmployee.Text = "Update";
                txtEmployee.Text = string.Empty;
                dateTimePicker1.Value = DateTime.Now;
                cboDepartment.Text = "Please Select...";
            }
            else
            {
                MessageBox.Show("You must select an Employee Department and enter an Employee description.");
            }

        }

        private void cmdDeleteEmployee_Click(object sender, EventArgs e)
        {
            var t = appDBContext.Employees.Find((int)dataGridView1.SelectedCells[0].Value);
            appDBContext.Employees.Remove(t);
            appDBContext.SaveChanges();

            refreshGrid();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            cmdUpdateEmployee.Text = "Update";
            txtEmployee.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;
            cboDepartment.Text = "Please Select...";
        }

        private void cmdUpdateEmployee_Click(object sender, EventArgs e)
        {
            if (cmdUpdateEmployee.Text == "Update")
            {

                txtEmployee.Text = dataGridView1.SelectedCells[1].Value.ToString();
                foreach (Department s in cboDepartment.Items)
                {
                    if (s.Name == dataGridView1.SelectedCells[2].Value.ToString())
                    {
                        cboDepartment.SelectedItem = s;
                    }
                }
                dateTimePicker1.Value = (DateTime)dataGridView1.SelectedCells[3].Value;

                cmdUpdateEmployee.Text = "Save";
            }
            else if (cmdUpdateEmployee.Text == "Save")
            {
                var updateEmployee = appDBContext.Employees.Find((int)dataGridView1.SelectedCells[0].Value);

                updateEmployee.Name = txtEmployee.Text;
                updateEmployee.DepartmentID = (cboDepartment.SelectedItem as Department).ID;
                updateEmployee.HireDate = dateTimePicker1.Value;

                appDBContext.SaveChanges();

                refreshGrid();

                cmdUpdateEmployee.Text = "Update";
                txtEmployee.Text = string.Empty;
                dateTimePicker1.Value = DateTime.Now;
                cboDepartment.Text = "Please Select...";
            }
        }
    }
}
