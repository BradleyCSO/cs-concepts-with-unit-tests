namespace Sandbox.Sorts.IComparer
{
    public class PersonSortByAgeComparer : IComparer<Person>
    {
        public int Compare(Person? x, Person? y) => x?.Age < y?.Age ? -1 : x?.Age > y?.Age ? 1 : 0;
    }
}