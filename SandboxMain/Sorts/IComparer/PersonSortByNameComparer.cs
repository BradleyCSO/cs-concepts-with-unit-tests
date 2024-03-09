namespace Sandbox.Sorts.IComparer
{
    public class PersonSortByNameComparer : IComparer<Person>
    {
        public int Compare(Person? x, Person? y) => x.Name.CompareTo(y.Name);
    }
}