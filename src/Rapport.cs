

public class Rapport
{
    public virtual string Naam() { return "Rapport"; }
    public virtual async Task<string> Genereer() { return "RapportTask"; }

    public async Task VoerUit()
    {
        
    }
    public async Task VoerPeriodiekUit()
    {
        
    }

}