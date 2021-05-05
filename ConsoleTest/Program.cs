using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            GetInstanceIds();

            Console.ReadLine();
        }

        private static async Task GetInstanceIds()
        {
            Parallel.For(0, 1000, async (i, state) =>
            {
                await GetInstanceId(i);
            });
        }

        private static async Task GetInstanceId(int iteration)
        {
            var start = DateTime.Now;
            var client = new HttpClient();
            var response = await client.GetAsync("https://tccollectiblesapi.azurewebsites.net/api/Category/instance");
            var instanceId = await response.Content.ReadAsStringAsync();
            var instance = instanceId == "9e332d9ad782a006d1770f3ea21a0947300e24c48bdf697e9d4afffcd4ca080a" ?
                "Instance One" : instanceId == "448e4e323f602cb98e3644f740492afc4c1165c09fa6bace99badbaff2863b46" ?
                "Instance Two" : instanceId;
            var timeTaken = (DateTime.Now - start).TotalMilliseconds;
            Console.WriteLine($"{instance}: {DateTime.Now.ToString("HH:mm:ss:fffffff")}; Time Taken: {timeTaken}ms; Iteration: {iteration}");
        }
    }
}
