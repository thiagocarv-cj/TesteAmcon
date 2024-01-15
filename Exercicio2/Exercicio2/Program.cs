using Newtonsoft.Json;
using RestSharp;

public class Program
{
    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        var totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);        
    }

    public static int getTotalScoredGoals(string team, int year)
    {
        var options = new RestClientOptions("https://jsonmock.hackerrank.com")
        {
            MaxTimeout = -1,
        };
        var client = new RestClient(options);
        var request = new RestRequest(@$"/api/football_matches?year={year}&team1={team}", Method.Get);
        var response = client.Execute(request);

        var dados = JsonConvert.DeserializeObject<Root>(response.Content);

        var paginas = 1;
        var total_paginas = dados.total_pages;
        var gols = 0;

        while (paginas <= total_paginas)
        {
            request = new RestRequest(@$"/api/football_matches?page={paginas}&year={year}&team1={team}", Method.Get);
            response = client.Execute(request);

            dados = JsonConvert.DeserializeObject<Root>(response.Content);

            
            foreach (var dado in dados.data)
            {
                if (dado.team1 == team)
                    gols = gols + int.Parse(dado.team1goals);

                if (dado.team2 == team)                         
                    gols = gols + int.Parse(dado.team2goals);
            }

            paginas++;
        }

        return gols;
    }

}

public class Datum
{
    public string competition { get; set; }
    public int year { get; set; }
    public string round { get; set; }
    public string team1 { get; set; }
    public string team2 { get; set; }
    public string team1goals { get; set; }
    public string team2goals { get; set; }
}

public class Root
{
    public int page { get; set; }
    public int per_page { get; set; }
    public int total { get; set; }
    public int total_pages { get; set; }
    public List<Datum> data { get; set; }
}


