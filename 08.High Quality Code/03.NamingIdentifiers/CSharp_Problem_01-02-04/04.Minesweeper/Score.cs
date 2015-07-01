namespace Minesweeper
{
    public class Score
    {
        private string userName;
        private int userPoints;

        public Score(string userName, int userPoints)
        {
            this.userName = userName;
            this.userPoints = userPoints;
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public int UserPoints
        {
            get { return userPoints; }
            set { userPoints = value; }
        }
    }
}