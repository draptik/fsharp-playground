namespace Domain
{
    /// <summary>
    /// Nullable properties...
    /// </summary>
    public class Dalek
    {
        public Dalek()
        {
        }

        public Dalek(int? id, int? power)
        {
            Id = id;
            Power = power;
        }

        public int? Id { get; set; }
        public int? Power { get; set; }
    }
}
