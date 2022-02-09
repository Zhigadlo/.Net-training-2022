using Paintings;
using StorageOfPaintings;

void Program()
{
    Painting painting1 = new Painting("name", "author", 2000, "genre", 3);
    Painting painting2 = new Painting("name", "author", 1871, "genre", 31);
    List<Painting> paintings = new List<Painting> { painting1 };

    Hall hall = new Hall(1, paintings);

    List<Hall> halls = new List<Hall> { hall };

    Gallery gallery = new Gallery(halls);

    Console.WriteLine(painting1.GetHashCode());
    Console.WriteLine(painting2.GetHashCode());
    //gallery.GetAllPaintings();
    /*
    var paints = gallery.GetPaintingsListByHalls(halls);

    foreach (var h in paints)
    {
        Console.WriteLine($"Hall number: {h.Key}");
        foreach(var p in h.Value)
        {
            Console.WriteLine(p.Name);
        }
    }*/
}

Program();

