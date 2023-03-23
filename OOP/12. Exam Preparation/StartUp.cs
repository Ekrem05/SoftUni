namespace UniversityCompetition
{
    using UniversityCompetition.Core;
    using UniversityCompetition.Core.Contracts;
    using UniversityCompetition.Models;
    using UniversityCompetition.Models.Contracts;
    using UniversityCompetition.Repositories;
    using UniversityCompetition.Repositories.Contracts;

    public class StartUp
    {
        static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();

        }
    }
}
