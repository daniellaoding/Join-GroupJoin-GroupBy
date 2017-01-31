using System;
using System.Linq;
using static Joins.Data;
using static Joins.Utils;

namespace Joins
{
    public static class JoinDemo
    {
        public static void JoinExample()
        {
            //Simple join
            WriteSectionTitle("Simple join");
            var addressBook = phoneBook.Join(
                inner: mailBook,
                outerKeySelector: phoneBookItem => phoneBookItem.Name,
                innerKeySelector: mailBookItem => mailBookItem.Name,
                resultSelector: (phoneBookItem, mailBookItem) => new AddressBookItem(phoneBookItem.Name, mailBookItem.Email, phoneBookItem.PhoneNumber));

            foreach (var item in addressBook)
            {
                Console.WriteLine(item.ToString());
            }


            //Case insensitive join with StringComparer
            WriteSectionTitle("Case insensitive join with StringComparer");
            var caseInsensitiveAddressBook = phoneBook.Join(
                inner: mailBook,
                outerKeySelector: phoneBookItem => phoneBookItem.Name,
                innerKeySelector: mailBookItem => mailBookItem.Name,
                resultSelector: (phoneBookItem, mailBookItem) => new AddressBookItem(phoneBookItem.Name, mailBookItem.Email, phoneBookItem.PhoneNumber),
                comparer: StringComparer.InvariantCultureIgnoreCase);

            foreach (var item in caseInsensitiveAddressBook)
            {
                Console.WriteLine(item.ToString());
            }

            //Query syntax join
            WriteSectionTitle("Query syntax join");
            var querySyntaxAddressBook = from phoneBookItem in phoneBook
                                         join mailBookItem in mailBook
                                         on phoneBookItem.Name equals mailBookItem.Name
                                         select new AddressBookItem(phoneBookItem.Name, mailBookItem.Email, phoneBookItem.PhoneNumber);

            foreach (var item in caseInsensitiveAddressBook)
            {
                Console.WriteLine(item.ToString());
            }
            //SAMPLE SQL FOR REFERENCE
            //SELECT phoneBookItem.[Name], mailBookItem.[Email], phoneBookItem.[PhoneNumber]
            //FROM [dbo].[phoneBook] phoneBookItem
            //JOIN [dbo].[mailBook] mailBookItem
            //  ON mailBookItem.[Name] = phoneBookItem.[Name]
        }
    }
}
