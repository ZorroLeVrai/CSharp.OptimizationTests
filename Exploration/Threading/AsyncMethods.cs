using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exploration.Threading;

class UserService
{
    public IEnumerable<string> GetUsers()
    {
        // Simule une requête
        Task.Delay(2000).Wait();
        return new List<string> { "Alice", "Bob", "Charlie" };
    }

    private long GetSum()
    {
        var sum = 0L;
        for (long i = 0; i < 1_000_000_000; i++)
        {
            ++sum;// Simule un traitement long
        }

        return sum;
    }

    public Task<IEnumerable<string>> GetUsersAsync()
    {
        bool isCache = true; // Simule une condition pour utiliser le cache
        if (isCache)
        {
            // Retourne les utilisateurs depuis le cache
            return Task.FromResult((IEnumerable<string>)new List<string> { "Alice", "Bob", "Charlie" });
        }

        var task = Task.Run(GetUsers); // Simule un traitement long en tâche de fond
        return task;
    }
}

internal class AsyncMethods
{
    public void Run()
    {
        var userService = new UserService();
        userService.GetUsersAsync();
        //var users = await Task.Run(userService.GetUsers);
        //foreach (var user in users)
        //{
        //    Console.WriteLine(user);
        //}
    }
}
