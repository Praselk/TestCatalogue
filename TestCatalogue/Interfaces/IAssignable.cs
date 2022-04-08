namespace TestCatalogue.Interfaces
{
    public interface IAssignable<T>
        where T : class
    {
        void AssignFrom(T source);
        void AssignTo(T target);
    }
}
