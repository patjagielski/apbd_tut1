﻿using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace tutorial_1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var websiteUrl = args[0];
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(websiteUrl);
            if (response.IsSuccessStatusCode)
            { 

                var htmlContent = await response.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z]+\\.[a-z]+", RegexOptions.IgnoreCase);
                var emailAddresses = regex.Matches(htmlContent);

                foreach (var match in emailAddresses)
                {
                    Console.WriteLine(match.ToString());
                }
            }
            Console.WriteLine("new branch");

        }
    }
}
