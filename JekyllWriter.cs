using System.IO;

namespace SubTextCVSToJekyll
{
    class JekyllWriter
    {
        public JekyllWriter(Subtext.Content content)
        {
            Content = content;
            ConvertHtmlToMarkdown = false;

            Path = @"\_posts\";
            FileName = content.DateAdded.ToString("yyyy-MM-dd") + "-" + CleanEntryNameForFileName(content.EntryName.ToLower()) + ".md";
        }

        public Subtext.Content Content { get; set; }

        public string Path { get; set; }
        public string FileName { get; set; }
        public bool ConvertHtmlToMarkdown { get; set; }

        public void WriteToFile()
        {
            var fullpath = System.IO.Path.GetFullPath("." + Path);
            Directory.CreateDirectory(fullpath);
            var writer = new StreamWriter(fullpath + FileName);
            writer.Write(ToString());
            writer.Close();
        }

        public override string ToString()
        {
            if (Content == null)
                return string.Empty;

            var redirectFrom = $"/archive/{Content.DateAdded:yyyy/MM/dd}/{Content.EntryName}.aspx";

            string body;
            if (ConvertHtmlToMarkdown)
            {
                var converter = new ReverseMarkdown.Converter();
                body = converter.Convert(Content.Text).Replace("<font size=\"2\">", "").Replace("</font>", "");
            }
            else
            {
                body = Content.Text;
            }

            return $"---\ntitle: \"{Content.Title}\"\ndate: {Content.DateAdded:yyyy-MM-dd}\nlayout: post\nredirect_from:\n - {redirectFrom}\n---\n{body}";
        }

        private string CleanEntryNameForFileName(string entryName)
        {
            var tempString = entryName;

            // remove ndash from title
            tempString = tempString.Replace("ndash", string.Empty);

            // remove single quote
            tempString = tempString.Replace("rsquo", string.Empty);

            // remove double dashes
            while (tempString.Contains("--"))
            {
                tempString = tempString.Replace("--", "-");
            }

            return tempString;
        }
    }
}