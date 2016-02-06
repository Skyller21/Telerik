using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomGeneratorWebServerControls
{
    public partial class RandomGenerator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonRandom_Click(object sender, EventArgs e)
        {

            if (this.MinNumber.Text == "")
            {
                this.MinNumber.Text = "0";
            }

            if (this.MaxNumber.Text == "")
            {
                this.MaxNumber.Text = "0";
            }

            var min = double.Parse(this.MinNumber.Text);
            var max = double.Parse(this.MaxNumber.Text);

            if (min > max)
            {
                this.Result.Text = "Enter max number bigger than min!";
                this.Result.Attributes.Add("class", "bg-danger");
                return;
            }

            var rand = new Random();

            this.Result.Text = (rand.NextDouble() * (max - min) + min).ToString("F2");
        }
    }
}