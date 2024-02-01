using Catalyst;
using Catalyst.Models;
using Persist.Entities;
using Repositories;
using Mosaik.Core;
using Services.Model;
namespace Services
{
    public class DataRecognition : IDataRecognition
    {
        private readonly IEntrySpotterService _entrySpotterService;

        public DataRecognition(IEntrySpotterService entrySpotterService)
        {
            _entrySpotterService = entrySpotterService;
        }
        public async Task<String> AanalyzText(string Query)
        {
            IEnumerable<EntrySpotter> ES = await _entrySpotterService.GetAllEntrySpotterAsync();
            List<DataRecognitionModel> NewListing =
            ES.GroupBy(d => d.Spotter.Id)
            .Select(newObject =>
            new DataRecognitionModel
            {
                Spotter = newObject.First().Spotter,
                EntryList = newObject.Select(item => item.Entry).ToList()
            }).ToList();
            Pipeline nlp = Pipeline.TokenizerFor(Language.English);
            foreach (DataRecognitionModel DR in NewListing)
            {
                Catalyst.Models.Spotter spotter = new Catalyst.Models.Spotter(Language.Any, 0, DR.Spotter.Title, DR.Spotter.Tag);
                spotter.Data.IgnoreCase = true;
                foreach (Entry sp in DR.EntryList)
                {
                    spotter.AddEntry(sp.Title);
                    nlp.Add(spotter);
                }
            }


            Document docAboutProgramming = new Document(Query, Language.English);

            nlp.ProcessSingle(docAboutProgramming);

            return PrintDocumentEntities(docAboutProgramming);
        }
        private static string PrintDocumentEntities(IDocument doc)
        {
            return $"Input text:\n\t'{doc.Value}'\n\nTokenized Value:\n\t'{doc.TokenizedValue(mergeEntities: true)}'\n\nEntities: \n{string.Join("\n", doc.SelectMany(span => span.GetEntities()).Select(e => $"\t{e.Value} [{e.EntityType.Type}]"))}";
        }
    }
}