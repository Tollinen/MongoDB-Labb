namespace TEST_MongoDB
{
    internal class InventoryController
    {
        IUI IO;
        DAO MovieDAO;
        NumberCheck input = new NumberCheck();

        public InventoryController(IUI IO, DAO MovieDAO)
        {
            this.IO = IO;
            this.MovieDAO = MovieDAO;
        }

        public void Start()
        {
            IO.Clear();
            IO.Print
                (
                $"[1] Create\n" +
                $"[2] Read\n" +
                $"[3] Update\n" +
                $"[4] Delete\n" +
                $"[5] Exit"
                );
            Menu();


        }

        public void Menu()
        {
            switch (input.CheckInt(5, true))
            {
                case 1:         //Create
                    IO.Clear();
                    MovieDAO.Create();
                    IO.Confirm();
                    break;

                case 2:         //Read
                    IO.Clear();
                    IO.Print(
                        $"[1] Read One\n" +
                        $"[2] Read Many\n" +
                        $"[3] Exit");

                    switch (input.CheckInt(3, true))
                    {
                        case 1:         //Read One
                            IO.Clear();
                            IO.Print("Put in the Movie ID of the movie you want to view.");
                            MovieDAO.Read(input.CheckInt(0, false));
                            IO.Confirm();
                            break;

                        case 2:         //Read All
                            foreach (var item in MovieDAO.ReadAll())
                            {
                                IO.Print(item);
                            }
                            IO.Confirm();
                            break;

                        case 3:         //Exit
                            break;

                        default:
                            IO.Print("Something went wrong.");
                            break;
                    }
                    break;

                case 3:         //Update
                    IO.Clear();
                    Console.WriteLine("Enter the movieid of the movie you want to edit:");
                    MovieDAO.Update(input.CheckInt(0, false));
                    IO.Confirm();

                    break;

                case 4:         //Delete
                    IO.Clear();
                    Console.WriteLine("Put in the Movie ID of the movie you want to delete.");
                    MovieDAO.Delete(input.CheckInt(0, false));
                    IO.Confirm();
                    break;

                case 5:         //Exit
                    IO.Exit();
                    break;

                default:
                    IO.Clear();
                    IO.Print("Something went wrong.");
                    IO.Confirm();
                    break;
            }

        }
    }
}
