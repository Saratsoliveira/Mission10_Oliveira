namespace API_Mission10_Oliveira.Data
{
    public interface IBowlingRepository
    {
        IEnumerable<Bowler> Bowlers { get; }
        IEnumerable<Team> Teams { get; }
        IEnumerable<Bowler> GetBowlersWithTeams(string[] teamNames);
    }
}
