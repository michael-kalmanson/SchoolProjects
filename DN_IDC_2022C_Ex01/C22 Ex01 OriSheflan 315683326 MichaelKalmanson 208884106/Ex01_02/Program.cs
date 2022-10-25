namespace Ex01_02
{
    public class Program
    {
        static int HEIGHT_OF_DIAMOND = 9;

        public static void Main()
        {
            Print_diamond(HEIGHT_OF_DIAMOND);
            System.Console.WriteLine("Press enter to terminate program.");
            System.Console.ReadLine();
        }

        // $G$ CSS-013 (-3) Bad parameter name (should be in the form of i_PascalCase).
        public static void Print_diamond(int i_height)
        {
            printDiamondRecursive(i_height, 1, (i_height - 1) / 2);
        }

        // $G$ CSS-013 (-3) Bad parameter name (should be in the form of i_PascalCase).
        private static void printDiamondRecursive(int i_height, int i_numStars, int i_numSpaces)
        {
            System.Text.StringBuilder lineOfDiamond = new System.Text.StringBuilder();
            bool weNeedToStop = !(i_numStars > i_height || i_numSpaces < 0);

            if (weNeedToStop)
            {
                for (int i = 0; i < i_numSpaces; i++)
                {
                    lineOfDiamond.Append(" ");
                }

                for (int i = 0; i < i_numStars; i++)
                {
                    lineOfDiamond.Append("*");
                }

                System.Console.WriteLine(lineOfDiamond);
                printDiamondRecursive(i_height, i_numStars + 2, i_numSpaces - 1);
                if (i_numStars < i_height || i_height % 2 == 0)
                {
                    // if necessary add another line
                    System.Console.WriteLine(lineOfDiamond);
                }
            }
        }
    }
}
