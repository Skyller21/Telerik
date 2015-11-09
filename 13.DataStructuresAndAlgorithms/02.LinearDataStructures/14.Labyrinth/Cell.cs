namespace _14.Labyrinth
{
    public class Cell<T>
    {
        public Cell(T row, T col)
        {
            Row = row;
            Col = col;
        }

        public T Row { get; set; }
        public T Col { get; set; }

        public override bool Equals(object obj)
        {
            var otherCell = (Cell<T>)obj;

            if (otherCell == null)
            {
                return false;
            }

            return (this.Col.Equals(otherCell.Col) && this.Row.Equals(otherCell.Row));
        }

        public override int GetHashCode()
        {
            return this.Row.GetHashCode() ^
                   this.Col.GetHashCode();
        }
    }
}