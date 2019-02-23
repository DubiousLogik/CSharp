using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SyntaxRunner.Enums;
using SyntaxRunner.Interfaces;
using SyntaxRunner.Models;

namespace SyntaxRunner.DateAndTime
{
    public class DateTimeExamples : IExampleRunner
    {
        public void RunExamples()
        {
            ReferenceDateHelper();
        }

        private static void ReferenceDateHelper()
        {
            var documentList = new Dictionary<string, int>(comparer: StringComparer.OrdinalIgnoreCase);
            var oldReferenceDate = DateTime.UtcNow.AddDays(-12);
            PopulateHistory(documentList, oldReferenceDate);

            var docRefList = new DocumentReferenceList(
                referenceDate: oldReferenceDate,
                documentList: documentList
            );

            Console.WriteLine("Initial state");
            PrintDocRefListToConsole(docRefList);

            Console.WriteLine("New state");
            docRefList.AddItem("spo_567");
            PrintDocRefListToConsole(docRefList);
        }

        private static void PopulateHistory(Dictionary<string, int> dl, DateTime oldReferenceDate)
        {
            AddItemMock(dl, oldReferenceDate, "spo_123", DateTime.Parse("2018-12-24"));
            AddItemMock(dl, oldReferenceDate, "spo_234", DateTime.Parse("2019-01-24"));
            AddItemMock(dl, oldReferenceDate, "spo_345", DateTime.Parse("2019-02-01"));
        }

        private static void AddItemMock(Dictionary<string, int> dl, DateTime oldReferenceDate, string itemId, DateTime itemDate)
        {
            dl[itemId] = DateDiffInDays(oldReferenceDate, itemDate);
        }

        private static int DateDiffInDays(DateTime referenceDate, DateTime itemDate)
        {
            return (referenceDate - itemDate).Days;
        }

        private static void PrintDocRefListToConsole(DocumentReferenceList drl)
        {
            Console.WriteLine();
            Console.WriteLine($"Reference Date {drl.ReferenceDate}");
            Console.WriteLine();

            foreach (var kvp in drl.DocumentList)
            {
                Console.WriteLine($"Key {kvp.Key} Age in days from ref date {kvp.Value}");
            }

            Console.WriteLine();
        }
    }
}
