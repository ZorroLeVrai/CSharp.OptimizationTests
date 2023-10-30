using CsvHelper;
using System.Globalization;

namespace OptimizationTests.Exercices;

public class RetrieveCommonListScenario
{
    const string person_list_path1 = "Exercices/CSV_Files/football_players.csv";
    const string person_list_path2 = "Exercices/CSV_Files/tennis_players.csv";

    private CommonListRetriever commonListRetriever;

    public RetrieveCommonListScenario()
    {
        var personList1 = GetPersons(person_list_path1);
        var personList2 = GetPersons(person_list_path2);
        commonListRetriever = new CommonListRetriever(personList1, personList2);

        IEnumerable<Person> GetPersons(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Person>().ToList();
            }
        }
    }

    public IEnumerable<Person> GetIntersectionUsingList()
    {
        return commonListRetriever.GetIntersectionUsingList();
    }

    public IEnumerable<Person> GetIntersectionUsingListLinqVersion()
    {
        return commonListRetriever.GetIntersectionUsingListLinqVersion();
    }

    public IEnumerable<Person> GetIntersectionUsingHashSet()
    {
        return commonListRetriever.GetIntersectionUsingHashSet();
    }
}
