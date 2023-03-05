namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            //string result = ExportAlbumsInfo(context, 9);
            //Console.WriteLine(result);

            string result2 = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(result2);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var sb = new StringBuilder();
            var albumsInfo = context.Albums
                .Where(a => a.ProducerId.HasValue
                    && a.ProducerId.Value == producerId)
                .ToArray()
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    a.Name,
                    ReleaseDate = a.ReleaseDate
                        .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .Select(s => new
                        {
                            SongName = s.Name,
                            Price = s.Price.ToString("f2"),
                            Writer = s.Writer.Name
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.Writer)
                        .ToArray(),
                    AlbumPrice = a.Price.ToString("f2")
                })
                .ToArray();

            foreach (var a in albumsInfo)
            {
                sb.AppendLine($"-AlbumName: {a.Name}");
                sb.AppendLine($"-ReleaseDate: {a.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {a.ProducerName}");
                sb.AppendLine($"-Songs:");

                int songNumber = 1;
                foreach (var s in a.Songs)
                {
                    sb.AppendLine($"---#{songNumber}");
                    sb.AppendLine($"---SongName: {s.SongName}");
                    sb.AppendLine($"---Price: {s.Price}");
                    sb.AppendLine($"---Writer: {s.Writer}");

                    songNumber++;
                }

                sb.AppendLine($"-AlbumPrice: {a.AlbumPrice}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int durationSeconds)
        {
            StringBuilder sb = new StringBuilder();
            var songsInfo = context.Songs
                 .AsEnumerable()
                 .Where(s => s.Duration.TotalSeconds > durationSeconds)
                 .Select(s => new
                 {
                     s.Name,
                     Perfomers = s.SongPerformers
                         .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                         .OrderBy(p => p)
                         .ToArray(),
                     WriterName = s.Writer.Name,
                     AlbumProducer = s.Album!.Producer!.Name,
                     Duration = s.Duration
                        .ToString("c")
                 })
                 .OrderBy(s => s.Name)
                 .ThenBy(s => s.WriterName)
                 .ToArray();

            int songNumber = 1;
            foreach (var s in songsInfo)
            {
                sb
                    .AppendLine($"-Song #{songNumber}")
                    .AppendLine($"---SongName: {s.Name}")
                    .AppendLine($"---Writer: {s.WriterName}");

                foreach (var performer in s.Perfomers)
                {
                    sb
                        .AppendLine($"---Performer: {performer}");
                }

                sb
                    .AppendLine($"---AlbumProducer: {s.AlbumProducer}")
                    .AppendLine($"---Duration: {s.Duration}");

                songNumber++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
