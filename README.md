# SubTextCVSToJekyll
Takes a CSV dump of a Subtext content SQL table and writes out Jekyll posts to markdown. 

Usage
-----

First Export the contents of the *subtext_Content* table
    
    SELECT [ID]
      ,[Title]
      ,[DateAdded]
      ,[PostType]
      ,[Author]
      ,[Email]
      ,[BlogId]
      ,[Description]
      ,[DateUpdated]
      ,[Text]
      ,[FeedBackCount]
      ,[PostConfig]
      ,[EntryName]
      ,[DateSyndicated]
      FROM [dbo].[subtext_Content]

Save the results to a standard CSV with a header row and quotes.

Then Run the converter program `SubTextCVSToJekyll.exe [export.csv]`

a folder *posts* will be created with individual markdown files for each entry.

License
-------

SubTextCVSToJekyll is covered under the terms of the [Apache 2.0 License](LICENSE)