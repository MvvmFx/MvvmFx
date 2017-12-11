using MvvmFx.CaliburnMicro;

namespace MasterDetailWithModel.ViewModels
{
    public interface IStudentEdit : IHaveModel
    {
        void Create();
        bool CanCreate { get; set; }
        void Save();
        bool CanSave { get; }
        void Delete();
        void Close();
    }
}