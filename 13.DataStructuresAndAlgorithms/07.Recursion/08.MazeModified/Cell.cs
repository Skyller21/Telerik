namespace _08.MazeModified
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
    }
}