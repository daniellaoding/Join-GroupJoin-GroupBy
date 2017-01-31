using System;
using System.Collections.Generic;
using System.Linq;
using static Joins.Data;
using static Joins.Utils;

namespace Joins
{
    public static class GroupByDemo
    {
        public static void GroupByExample()
        {
            //Simple groupBy with keySelector
            WriteSectionTitle("Simple .GroupBy()");
            var groupedList = myShoppingList.GroupBy(x => x.Type);

            foreach (var group in groupedList)
            {
                Console.WriteLine($"Items in group {group.Key}:");
                foreach (var item in group)
                {
                    Console.WriteLine(item.ToString());
                }
            }


            //You can also use ToDictionary() easily:
            Dictionary<string, List<Product>> dictionary = groupedList.ToDictionary(g => g.Key, g => g.ToList());
            Dictionary<string, int> countDictionary = groupedList.ToDictionary(g => g.Key, g => g.Count());
            Dictionary<string, IOrderedEnumerable<Product>> orderedValuesDictionary = groupedList.ToDictionary(g => g.Key, g => g.OrderBy(x => x.Name));

            //Or do other things
            IEnumerable<string> groceryList = groupedList.Where(group => group.Key == "Grocery")
                .SelectMany(group =>
                {
                    return group.AsEnumerable().Select(item => item.Name);
                });
        }

        public static void AdvancedGroupByExample()
        {
            //GroupBy with element selector
            WriteSectionTitle("GroupBy() with element selector set on Email");

            var elementSelectorGroup = complexMailBook.GroupBy(
                keySelector: x => x.Name,
                elementSelector: x => x.Email,
                comparer: StringComparer.InvariantCultureIgnoreCase);


            foreach (var group in elementSelectorGroup)
            {
                Console.WriteLine($"Items in group {group.Key}:");
                foreach (var item in group)
                {
                    Console.WriteLine(item.ToString());
                }
            }

            //GroupBy with result selector
            WriteSectionTitle("GroupBy() with projection to ComplexAddressBookItem with resultSelector");

            var resultSelectorGroupByResults = complexMailBook.GroupBy(
                keySelector: x => x.Name,
                resultSelector: (key, mailContactItemsGroup) => new ComplexAddressBookItem(key, "Empty number", mailContactItemsGroup.Select(mailContactItem => mailContactItem.Email)),
                comparer: StringComparer.InvariantCultureIgnoreCase
                );

            foreach (var item in resultSelectorGroupByResults)
            {
                Console.WriteLine(item.ToString());
            }

            //GroupBy with element and result selector
            WriteSectionTitle("GroupBy() with projection to ComplexAddressBookItem with resultSelector and elementSelector");

            var resultAndElementSelectorGroupBy = complexMailBook.GroupBy(
                keySelector: x => x.Name,
                elementSelector: x => x.Email,
                resultSelector: (key, emailCollection) => new ComplexAddressBookItem(key, "Empty number", emailCollection),
                comparer: StringComparer.InvariantCultureIgnoreCase
                );

            foreach (var item in resultSelectorGroupByResults)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
