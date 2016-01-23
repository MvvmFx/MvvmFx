using System.ComponentModel;
using System.Linq;

namespace FamilyBusiness
{
    public class FamilyMemberInfo : INotifyPropertyChanged
    {
        #region Static stuff

        private static readonly FamilyMemberInfoList FamilyMemberInfos = new FamilyMemberInfoList();
        private int? _parentId;
        private int _familyMemberId;
        private string _name;

        #endregion

        #region Properties

        public int FamilyMemberId
        {
            get { return _familyMemberId; }
            internal set
            {
                if (_familyMemberId != value)
                {
                    _familyMemberId = value;
                    NotifyPropertyChanged("FamilyMemberId");
                }
            }
        }

        public string Name
        {
            get { return _name; }
            internal set
            {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        public int? ParentId
        {
            get { return _parentId; }
            set
            {
                if (_parentId != value)
                {
                    _parentId = value;
                    var familyMember = FamilyMember.GetFamilyMemberById(FamilyMemberId);
                    if (familyMember.ParentId != _parentId)
                    {
                        familyMember.ParentId = _parentId;
                        familyMember.Save();
                    }
                    NotifyPropertyChanged("ParentId");
                }
            }
        }

        #endregion

        #region Constuctor

        internal FamilyMemberInfo()
        {
            // use factory methods
        }

        #endregion

        #region Factory methods

        internal static FamilyMemberInfo NewFamilyMemberInfo(int familyMemberId, string name, int? parentId)
        {
            return new FamilyMemberInfo {FamilyMemberId = familyMemberId, Name = name, ParentId = parentId};
        }

        internal static void AddNewFamilyMemberInfo(int familyMemberId, string name, int? parentId)
        {
            FamilyMemberInfos.Add(NewFamilyMemberInfo(familyMemberId, name, parentId));
        }

        internal static void Update(int familyMemberId, string name, int? parentId)
        {
            FamilyMemberInfos.Update(familyMemberId, name, parentId);
        }

        internal static void Remove(int familyMemberId)
        {
            FamilyMemberInfos.Remove(familyMemberId);
        }

        public static FamilyMemberInfoList GetFamilyMemberInfoList()
        {
            return FamilyMemberInfos;
        }

        public static FamilyMemberInfo GetFamilyMemberById(int familyMemberId)
        {
            return
                FamilyMemberInfos.FirstOrDefault(familyMemberInfo => familyMemberInfo.FamilyMemberId == familyMemberId);
        }

        #endregion

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}