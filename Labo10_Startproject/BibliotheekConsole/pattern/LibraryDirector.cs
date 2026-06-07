using Catalogus;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace BibliotheekConsole.pattern
{
    internal class LibraryDirector
    {
        readonly IBuilder builder;

        internal LibraryDirector(IBuilder builder)
        {
            this.builder = builder;
        }


        // Idea: Use Factory Method Pattern for not only reading from JSON, but also from XML, CSV, etc.
        public IBibItem BuildLibraryFromYAML(string filename)
        {
            StreamReader streamReader = new StreamReader(filename);
            string content = streamReader.ReadToEnd();
            var deserializer = new DeserializerBuilder().Build();
            var library = deserializer.Deserialize<dynamic>(content);

            builder.NewLibrary(library["id"], library["name"]);
            foreach (var afdeling in library["afdelingen"])
            {
                BuildAfdeling(afdeling);
            }
            return builder.Build();

        }

        private void BuildAfdeling(dynamic afdeling)
        {
            builder.StartAfdeling(afdeling["id"], afdeling["name"]);
            bool hasTijdschriften = ((IDictionary<object, object>)afdeling).ContainsKey("tijdschriften");
            if (hasTijdschriften)
            {
                foreach (var tijdschrift in afdeling["tijdschriften"])
                {
                    DateTime date = DateTime.ParseExact(tijdschrift["date"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    builder.StartTijdschrift(tijdschrift["id"], tijdschrift["title"], date, tijdschrift["uitgeverij"]);
                    foreach (var artikel in tijdschrift["artikels"])
                    {
                        builder.AddArtikel(artikel["id"], artikel["title"], artikel["auteur"]);
                    }
                    builder.EndTijdschrift();
                }
            }

            bool hasBoeken = ((IDictionary<object, object>)afdeling).ContainsKey("boeken");
            if (hasBoeken)
            {
                foreach (var boek in afdeling["boeken"])
                {
                    builder.AddBoek(boek["id"], boek["title"], boek["auteur"], boek["uitgeverij"], Int32.Parse(boek["jaartal"]));
                }
            }

            bool hasAfdelingen = ((IDictionary<object, object>)afdeling).ContainsKey("afdelingen");
            if (hasAfdelingen)
            {
                foreach (var subAfdeling in afdeling["afdelingen"])
                {
                    // Recursive
                    BuildAfdeling(subAfdeling);
                }
            }
            builder.EndAfdeling();
        }
    }
}
