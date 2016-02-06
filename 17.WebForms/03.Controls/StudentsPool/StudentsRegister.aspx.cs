using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentsPool
{
    public partial class StudentsRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetSpecialties();
        }

        protected void DropDownListUniversities_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSpecialties();
        }

        protected void DropDownListSpecialties_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ListBoxCourses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public IQueryable<string> GetUniversities()
        {
            return (new[] { "Sofia University", "Plovdiv University", "Telerik Academy" }).AsQueryable();
        }

        public void GetSpecialties()
        {
            if (this.DropDownListUniversities.SelectedValue == "Sofia University")
            {
                this.DropDownListSpecialties.DataSource = new[] { "Sofia University", "Plovdiv University", "Telerik Academy" };
            }
            else
            {

                this.DropDownListSpecialties.DataSource = "";
            }
            this.DropDownListSpecialties.DataBind();
        }

        public IQueryable<string> GetCourses()
        {
            return (new[] { "Math101", "Algorithms101" }).AsQueryable();
        }


        protected void RegBtn_Click(object sender, EventArgs e)
        {
            this.Name.Text = this.FirstName.Text + " " + this.LastName.Text;
            this.Number.Text = "Faculty number: " + this.FacultyNumber.Text;
            this.UniSpec.Text = "University " + this.DropDownListUniversities.SelectedValue + " | Speciality " + this.DropDownListSpecialties.SelectedValue;
            var selectedCourses = new List<string>();
            foreach (ListItem item in this.ListBoxCourses.Items)
            {
                if (item.Selected)
                {
                    selectedCourses.Add(item.Value);
                }
            }
            this.SelectedCourses.Text = "Courses: " + string.Join(", ", selectedCourses);
        }
    }
}