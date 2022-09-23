

public class DemografischRapport : Rapport
{
    private DatabaseContext context;
    public override string Naam() { return "DemografischRapport"; }
    public override async Task<string> Genereer() { return "DemografischRapportTask"; }
    public DemografischRapport(DatabaseContext context)
    {
        this.context = context;
    }

    public async Task<int> AantalGebruikers()
    {
        return context.Gebruikers.Count();
    }
    public async Task<bool> AlleGastenHebbenReservering()
    {
        return true;
    }
    public async Task<int> AantalSinds(DateTime d, bool uniek)
    {
        return 0;
    }
    public async Task<Gast?> GastBijEmail(string email)
    {
        return null;
    }
    public async Task<Gast?> GastBijGeboorteDatum(DateTime geboorteDatum)
    {
        return null;
    }
    public async Task<int> PercentageBejaarden()
    {
        return 0;
    }
    public async Task<int> HoogsteLeeftijd()
    {
        return 0;
    }
    public IEnumerable<Gast> Blut(IEnumerable<Gast> gasten)
    {
        return new List<Gast>();
    }
    public IEnumerable<(string, int)> VerdelingPerDag()
    {
        return new List<(string, int)>();
    }
    public IEnumerable<(Gast, int)> GastenMetActiviteit(IEnumerable<Gast> gasten)
    {
        return new List<(Gast, int)>();
    }
    public async Task<int> FavorietCorrect()
    {
        return 0;
    }

}