using System.Collections.Generic;

namespace Joins
{
    public static class Data
    {
        #region For GroupBy
        public static IEnumerable<Product> myShoppingList
        {
            get
            {
                yield return new Product("Bacon", "Grocery");
                yield return new Product("Batteries", "Electronics");
                yield return new Product("Juice", "Grocery");
                yield return new Product("Bread", "Grocery");
                yield return new Product("Painkillers", "Pharmaceuticals");
            }
        }
        #endregion

        #region For Join
        public static IEnumerable<PhoneContactItem> phoneBook
        {
            get
            {
                yield return new PhoneContactItem("Rafal", "555 555");
                yield return new PhoneContactItem("John", "555 666");
                yield return new PhoneContactItem("Bob", "555 777");
                yield return new PhoneContactItem("Jim", "555 888");
            }
        }

        public static IEnumerable<MailContactItem> mailBook
        {
            get
            {
                yield return new MailContactItem("Rafal", "rafal@(thisblogdomain).net");
                yield return new MailContactItem("John", "john@somedomain.com");
                yield return new MailContactItem("bob", "bob@somedomain.com");
                yield return new MailContactItem("jim", "jim@somedomain.com");
            }
        }
        #endregion

        #region For GroupJoin
        public static IEnumerable<MailContactItem> complexMailBook
        {
            get
            {
                yield return new MailContactItem("Rafal", "rafal@(thisblogdomain).net");
                yield return new MailContactItem("John", "john@somedomain.com");
                yield return new MailContactItem("bob", "bob@somedomain.com");
                yield return new MailContactItem("jim", "jim@somedomain.com");
                yield return new MailContactItem("John", "john@otherdomain.com");
                yield return new MailContactItem("bob", "bob@otherdomain.com");
                yield return new MailContactItem("jim", "jim@otherdomain.com");
                yield return new MailContactItem("John", "john@sampledomain.com");
                yield return new MailContactItem("bob", "bob@sampledomain.com");
                yield return new MailContactItem("jim", "jim@sampledomain.com");
            }
        }

        #endregion
    }
}
