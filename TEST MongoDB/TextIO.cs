namespace TEST_MongoDB
{
    internal class TextIO : IUI
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Exit()
        {
            System.Environment.Exit(0);
        }

        public void Confirm()
        {
            Console.WriteLine("[Enter] to go back.");
            Console.ReadLine();
        }
    }
}
