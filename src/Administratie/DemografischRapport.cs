

public class DemografischRapport : Rapport
{
    private DatabaseContext context;
    public override string Naam() { return "DemografischRapport"; }
    
    public override async Task<string> Genereer()
    {
        string ret = "Dit is een demografisch rapport: \n";
        ret += $"Er zijn in totaal {await AantalGebruikers()} gebruikers van dit platform (dat zijn gasten en medewerkers)\n";
        var dateTime = new DateTime(2000, 1, 1);
        ret += $"Er zijn {await AantalSinds(dateTime)} bezoekers sinds {dateTime}\n";
        if (await AlleGastenHebbenReservering())
            ret += "Alle gasten hebben een reservering\n";
        else
            ret += "Niet alle gasten hebben een reservering\n";
        ret += $"Het percentage bejaarden is {await PercentageBejaarden()}\n";

        ret += $"De oudste gast heeft een leeftijd van {await HoogsteLeeftijd()} \n";

        ret += "De verdeling van de gasten per dag is als volgt: \n";
        var dagAantallen = await VerdelingPerDag();
        var totaal = dagAantallen.Select(t => t.aantal).Max();
        foreach (var dagAantal in dagAantallen)
            ret += $"{dagAantal.dag}: {new string('#', (int)(dagAantal.aantal / (double)totaal * 20))}\n";

        ret += $"{await FavorietCorrect()} gasten hebben de favoriete attractie inderdaad het vaakst bezocht. \n";

        return ret;
    }

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
        return await Task.Run(() => context.Gasten.Any(g => g.Reserveringen.Count() > 0));
    }
    public async Task<int> AantalSinds(DateTime datum, bool uniek = false)
    {
        if (uniek) await Task.Delay(1000); // moeilijke berekening
        return await Task.Run(() => context.Reserveringen.Select(g => g.Tijd).Where(tijd => tijd.Eindigt()).Count());
    }
    public async Task<Gast?> GastBijEmail(string email)
    {
        return await Task.Run(() => context.Gasten.SingleOrDefault(g => g.Email == email));
    }
    public async Task<Gast?> GastBijGeboorteDatum(DateTime geboorteDatum)
    {
        return await Task.Run(() => context.Gasten.Single(g => g.GeboorteDatum == geboorteDatum));
    }
    public async Task<int> PercentageBejaarden()
    {
        return await Task.Run(() =>
        context.Gasten.Select(g => g.GeboorteDatum).Where(d => DateTime.Compare(DateTime.Now, d) > 80).Count() / context.Gasten.Count() * 100
        );
    }
    public async Task<int> HoogsteLeeftijd()
    {
        return await Task.Run(() => DateTime.Now.Year - context.Gasten.Select(g => g.GeboorteDatum.Year).Min());
    }
    public IEnumerable<Gast> Blut(IEnumerable<Gast> gasten)
    {
        return gasten.Select(g => g).Where(c => c.Credits < 0);
    }
    public async Task<(string dag , int aantal)> VerdelingPerDag()
    {
        return ("asdf", 3);
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