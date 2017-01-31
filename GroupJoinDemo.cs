using System;
using System.Linq;
using static Joins.Data;
using static Joins.Utils;

namespace Joins
{
    public static class GroupJoinDemo
    {
        public static void GroupJoinExample()
        {
            //Let's try using join for more complex situation
            WriteSectionTitle("Try using join for more complex situation");
            var addressBook = phoneBook.Join(
                inner: complexMailBook,
                outerKeySelector: phoneBookItem => phoneBookItem.Name,
                innerKeySelector: complexMailBookItem => complexMailBookItem.Name,
                resultSelector: (phoneBookItem, complexMailBookItem) => new ComplexAddressBookItem(phoneBookItem.Name,
                    phoneBookItem.PhoneNumber,
                    new string[] { complexMailBookItem.Email }), /*No way to put multiple emails here :(*/
                comparer: StringComparer.InvariantCultureIgnoreCase
                );

            foreach (var item in addressBook)
            {
                Console.WriteLine(item.ToString());
            }

            //Using Group join to join multiple items together
            WriteSectionTitle("Using Group join to join multiple items");
            var complexAddressBook = phoneBook.GroupJoin(
                inner: complexMailBook,
                outerKeySelector: phoneBookItem => phoneBookItem.Name,
                innerKeySelector: mailBookItem => mailBookItem.Name,
                resultSelector: (phoneBookItem/*type of: PhoneContactItem*/, mailBookItems/*type of: IEnumerable<MailContactItem>*/) =>
                    new ComplexAddressBookItem(phoneBookItem.Name, phoneBookItem.PhoneNumber, mailBookItems.Select(x => x.Email)),
                comparer: StringComparer.InvariantCultureIgnoreCase
                );

            foreach (var item in complexAddressBook)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
