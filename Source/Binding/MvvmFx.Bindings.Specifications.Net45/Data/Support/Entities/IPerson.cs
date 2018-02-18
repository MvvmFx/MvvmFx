namespace MvvmFx.Bindings.Specifications.Support.Entities
{
    public interface IPerson
    {
        string Name { get; set; }

        int Age { get; set; }

        Gender Gender { get; set; }

        string Details { get; set; }

        IAddress Address { get; }
    }
}