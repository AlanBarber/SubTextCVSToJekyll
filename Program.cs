using System;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace SubTextCVSToJekyll
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SubTextCSVToJekyll - Coverts CSV SQL dump to Jekyll post");
            Console.WriteLine("");

            if (File.Exists(args[0]))
            {
                Console.WriteLine("Opening file '" + args[0] + "'...");
                var stream = new StreamReader(args[0]);
                var csvConfig = new Configuration()
                {
                    Delimiter = ",",
                    HasHeaderRecord = true
                };
                var csvReader = new CsvReader(stream, csvConfig);
                var blogPosts = csvReader.GetRecords<Subtext.Content>();

                foreach (var post in blogPosts)
                {
                    Console.WriteLine("  Writing post '" + post.Title + "'...");
                    var writer = new JekyllWriter(post) {ConvertHtmlToMarkdown = true};
                    writer.WriteToFile();
                }

                Console.WriteLine("done.");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Error: Unable to open file '" + args[0] + "'.");
            }
        }
    }
}
