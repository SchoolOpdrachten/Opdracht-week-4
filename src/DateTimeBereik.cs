
public class DateTimeBereik
{
    public DateTime Begin { get; set; }
    public DateTime Eind { get; set; }

    public bool Eindigt()
    {
        return Eind != DateTime.MinValue;
    }
    public bool Overlapt(DateTimeBereik ander)
    {
        return Begin < ander.Eind && Eind > ander.Begin;
    }
}