using TEST_MongoDB;

IUI io;
DAO MovieDao;
bool isMeny = true;

io = new TextIO();
MovieDao = new MongoDAO("MovieStore", "mongodb+srv://Adam:Tollin@cluster0.wkm2mf9.mongodb.net/test");

InventoryController Controller = new InventoryController(io, MovieDao);

while (isMeny)
{
    Controller.Start();
}