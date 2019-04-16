using System;
using System.Collections.Generic;
using SyntaxRunner.Interfaces;
using SyntaxRunner.Models;

using Newtonsoft.Json;

namespace SyntaxRunner.DateAndTime
{
    public class DateTimeExamples : IExampleRunner
    {
        private static readonly string docRefListJson = @"{
	        ""referenceDate"": ""2019-03-19T00:00:00"",
	        ""documentList"": {
		        ""spo_124"": 29,
		        ""spo_234"": 25,
		        ""spo_345"": 13,
		        ""spo_567"": 0

            },
	        ""maxAgeInDays"": 30,
	        ""maxDocumentCount"": 100
        }";

        private static readonly string docRefListJsonNoList = @"{
	        ""referenceDate"": ""2019-03-19T00:00:00"",
	        ""maxAgeInDays"": 30,
	        ""maxDocumentCount"": 100
        }";

        public void RunExamples()
        {
            ReferenceDateHelper();
        }

        private static void ReferenceDateHelper()
        {
            var dismissedDocuments = new Dictionary<string, int>(comparer: StringComparer.OrdinalIgnoreCase);
            var oldReferenceDate = DateTime.UtcNow.AddDays(-5);
            PopulateHistory(dismissedDocuments, oldReferenceDate);

            var docRefList = new CompactDocumentActionList(
                maxAgeInDays: 30,
                maxDocumentCount: 100,
                referenceDateOverride: oldReferenceDate,
                documentList: dismissedDocuments
            );

            Console.WriteLine("Initial state");
            PrintDocRefListToConsole(docRefList);

            Console.WriteLine("New state");
            docRefList.AddItem("spo_567");
            PrintDocRefListToConsole(docRefList);

            

            var drl = new CompactDocumentActionList(30, 100);
            drl.AddItem("spo_678");
            PrintDocRefListToConsole(drl);

            TestSerialization(docRefList);
        }

        private static void PopulateHistory(Dictionary<string, int> dl, DateTime oldReferenceDate)
        {
            // current items
            AddItemMock(dl, oldReferenceDate, "spo_124", oldReferenceDate.AddDays(-24));
            AddItemMock(dl, oldReferenceDate, "spo_234", oldReferenceDate.AddDays(-20));
            AddItemMock(dl, oldReferenceDate, "spo_345", oldReferenceDate.AddDays(-8));

            // old items
            AddItemMock(dl, oldReferenceDate, "spo_923", oldReferenceDate.AddDays(-25));
            AddItemMock(dl, oldReferenceDate, "spo_924", oldReferenceDate.AddDays(-61));
            AddItemMock(dl, oldReferenceDate, "spo_934", oldReferenceDate.AddDays(-65));
            AddItemMock(dl, oldReferenceDate, "spo_945", oldReferenceDate.AddDays(-62));
        }

        private static void AddItemMock(Dictionary<string, int> dl, DateTime oldReferenceDate, string itemId, DateTime itemDate)
        {
            dl[itemId] = DateDiffInDays(oldReferenceDate, itemDate);
        }

        private static int DateDiffInDays(DateTime referenceDate, DateTime itemDate)
        {
            return (referenceDate - itemDate).Days;
        }

        private static void PrintDocRefListToConsole(CompactDocumentActionList drl)
        {
            Console.WriteLine();
            Console.WriteLine($"Obj Id {drl.GetHashCode().ToString()}");
            Console.WriteLine($"Reference Date {drl.ReferenceDate}");
            Console.WriteLine($"Max Doc Count {drl.MaxDocumentCount}");
            Console.WriteLine($"Max Doc Age {drl.MaxAgeInDays}");
            Console.WriteLine();

            if (drl.DocumentList == null)
            {
                Console.WriteLine("doc list was null");
            }
            else
            {
                Console.WriteLine($"doc list count {drl.DocumentList.Count}");
            }

            foreach (var kvp in drl.DocumentList)
            {
                Console.WriteLine($"Key {kvp.Key} Age in days from ref date {kvp.Value}");
            }

            Console.WriteLine();
        }

        private static void TestSerialization(CompactDocumentActionList docRefList)
        {
            Console.WriteLine($"Json for docRefList: {JsonConvert.SerializeObject(docRefList)}");

            Console.WriteLine("Deserializing valid json");
            var deserializedDocRefList = JsonConvert.DeserializeObject<CompactDocumentActionList>(docRefListJson);

            Console.WriteLine("== Printing deserialized ========================");
            PrintDocRefListToConsole(deserializedDocRefList);

            Console.WriteLine("Deserializing json missing doc list");
            deserializedDocRefList = JsonConvert.DeserializeObject<CompactDocumentActionList>(docRefListJsonNoList);

            Console.WriteLine("== Printing deserialized no list ========================");
            PrintDocRefListToConsole(deserializedDocRefList);
        }
    }
}
