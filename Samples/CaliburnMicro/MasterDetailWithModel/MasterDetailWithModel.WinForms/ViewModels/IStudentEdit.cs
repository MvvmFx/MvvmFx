using MvvmFx.CaliburnMicro;

namespace MasterDetailWithModel.ViewModels
{
    public interface IStudentEdit : IHaveModel
    {
        void CreateNew();
        bool CanCreateNew { get; set; }
        void Save();
        bool CanSave { get; set; }
        void Delete();
        void Close();
    }
}