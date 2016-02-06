using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomNumberGenerator
{
    public partial class RandomNumber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonRandom_Click(object sender, EventArgs e)
        {

            if (this.MinNumber.Value == "")
            {
                this.MinNumber.Value = "0";
            }

            if (this.MaxNumber.Value == "")
            {
                this.MaxNumber.Value = "0";
            }

            var min = double.Parse(this.MinNumber.Value);
            var max = double.Parse(this.MaxNumber.Value);

            if (min > max)
            {
                this.Result.Value = "Enter max number bigger than min!";
                this.Result.Attributes.Add("class", "bg-danger");
                return;
            }

            var rand = new Random();

            this.Result.Value = (rand.NextDouble()*(max- min) + min).ToString("F2");
        }
    }
}