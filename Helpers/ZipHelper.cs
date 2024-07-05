using System;
using System.IO.Compression;

namespace ZipHelper.Create
{
    public static class ZipCreateFile
    {
        public static byte[] CreateZipFromMemoryStream (Dictionary<string, Stream> files)
        {
            MemoryStream mem = new MemoryStream();

            using(ZipArchive archive = new ZipArchive(mem, ZipArchiveMode.Create, true))
            {
                foreach(var item in files)
                {
                    var entry = archive.CreateEntry(item.Key, CompressionLevel.Optimal);

                    using(Stream stream = entry.Open())
                    {
                        item.Value.CopyTo(stream);
                    }
                }
            }

            mem.Position = 0;

            byte[] zipBytes = mem.ToArray();

            mem.Dispose();

            return zipBytes;
        }
    }
}