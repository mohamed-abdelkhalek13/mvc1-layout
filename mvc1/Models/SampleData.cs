namespace MVC.Models
{
    public static class SampleData
    {
        public static List<Guests> guests = new List<Guests>()
        {
            new Guests(){name="ahmed", email="ahmed@123", phone=0123456888, willAttend= "yes" },
            new Guests(){name="mohamed", email="mohamed@1", phone=0123456555, willAttend= "no" },
            new Guests(){name="sara", email="sara@2", phone=0103456587, willAttend= "yes" },
        };
        public static void addGuest(Guests guest)
        {
            guests.Add(guest);
        }
    }
}
