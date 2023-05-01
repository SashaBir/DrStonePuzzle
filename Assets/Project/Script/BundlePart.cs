namespace Puzzle
{
    public class BundlePart
    {
        public BundlePart(PuzzlePart puzzlePart, FormPart formPart)
        {
            PuzzlePart = puzzlePart;
            FormPart = formPart;
        }

        public PuzzlePart PuzzlePart { get; }

        public FormPart FormPart { get; }

        public static bool operator ==(BundlePart a, BundlePart b)
        {
            if (ReferenceEquals(a, null) == true)
            {
                return false;
            }

            if ((object)a == null || (object)b == null)
            {
                return false;
            }

            return a.PuzzlePart == b.PuzzlePart && a.FormPart == b.FormPart;
        }

        public static bool operator !=(BundlePart a, BundlePart b)
        {
            if (ReferenceEquals(a, null) == true)
            {
                return false;
            }

            if ((object)a == null || (object)b == null)
            {
                return false;
            }

            return a.PuzzlePart != b.PuzzlePart || a.FormPart != b.FormPart;
        }
    }
}