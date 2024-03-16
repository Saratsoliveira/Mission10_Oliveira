namespace API_Mission10_Oliveira.Data
{
    public class EFBowlingRepository: IBowlingRepository
    {

        private BowlingContext _context;

        public EFBowlingRepository(BowlingContext temp)
        {
            _context = temp;
        }

        public IEnumerable<Bowler> Bowlers => _context.Bowlers;
        public IEnumerable<Team> Teams => _context.Teams;

        //chat gpt code to be able to join tables and get data, learn more about it
        public IEnumerable<Bowler> GetBowlersWithTeams(string[] teamNames)
        {
            var joinedData = from bowler in _context.Bowlers
                             join team in _context.Teams
                             on bowler.TeamId equals team.TeamId
                             where teamNames.Contains(team.TeamName) //Filter teams based on list passed in
                             select new
                             {
                                 BowlerId = bowler.BowlerId,
                                 BowlerLastName = bowler.BowlerLastName,
                                 BowlerFirstName = bowler.BowlerFirstName,
                                 BowlerMiddleInit = bowler.BowlerMiddleInit,
                                 BowlerAddress = bowler.BowlerAddress,
                                 BowlerCity = bowler.BowlerCity,
                                 BowlerState = bowler.BowlerState,
                                 BowlerZip = bowler.BowlerZip,
                                 BowlerPhoneNumber = bowler.BowlerPhoneNumber,
                                 TeamID = bowler.TeamId,
                                 TeamName = team.TeamName
                             };

            var bowlersWithTeams = joinedData
                .Select(b => new Bowler
                {
                    BowlerId = b.BowlerId,
                    BowlerLastName = b.BowlerLastName,
                    BowlerFirstName = b.BowlerFirstName,
                    BowlerMiddleInit = b.BowlerMiddleInit,
                    BowlerAddress = b.BowlerAddress,
                    BowlerCity = b.BowlerCity,
                    BowlerState = b.BowlerState,
                    BowlerZip = b.BowlerZip,
                    BowlerPhoneNumber = b.BowlerPhoneNumber,
                    Team = new Team { TeamName = b.TeamName }
                })
                .ToList();

            return bowlersWithTeams;
        }

    }
}
