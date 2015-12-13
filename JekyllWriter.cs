using System.IO;

namespace SubTextCVSToJekyll
{
    class JekyllWriter
    {
        public JekyllWriter()
        {
            Content = null;
        }

        public JekyllWriter(SubTextCVSToJekyll.Subtext.Content content)
        {
            Content = content;

            Path = @"\_posts\";
            FileName = content.DateAdded.ToString("yyyy-MM-dd") + "-" + content.EntryName.ToLower() + ".md";
        }

        public SubTextCVSToJekyll.Subtext.Content Content { get; set; }

        public string Path { get; set; }
        public string FileName { get; set; }

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

            var redirectFrom = string.Format("/archive/{0}/{1}.aspx",
                Content.DateAdded.ToString("yyyy/MM/dd"),
                Content.EntryName);

            return string.Format("---\n" +
                                 "title: \"{0}\"\n" +
                                 "date: {1}\n" +
                                 "layout: post\n" +
                                 "redirect_from:\n" +
                                 " - {2}\n" +
                                 "---\n{3}",
                                 Content.Title,
                                 Content.DateAdded.ToShortDateString(),
                                 redirectFrom,
                                 Content.Text);
        }
    }
}