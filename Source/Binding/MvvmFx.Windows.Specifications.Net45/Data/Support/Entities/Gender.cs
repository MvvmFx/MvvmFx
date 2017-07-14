namespace MvvmFx.Windows.Specifications.Support.Entities
{
    public class Gender : EntityBase
    {
        private readonly string _display;

        public static readonly Gender Male = new Gender("Male");
        public static readonly Gender Female = new Gender("Female");

        private Gender(string display)
        {
            _display = display;
        }

        public override string ToString()
        {
            return _display;
        }
    }
}
