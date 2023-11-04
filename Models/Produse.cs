namespace CosCumparaturi.Models
{
    public class Produse
    {
        public int Id { get; set; }
        public string? Denumire { get; set; }
        public string? Descriere { get; set; }

        public int Canti { get; set; }

        public DateTime Valabilitate { get; set; }
    }
}
