using System;
using System.ComponentModel;
using System.Linq;

namespace FamilyBusiness
{
    public class FamilyMember : INotifyPropertyChanged
    {
        #region Static stuff

        private static int _lastId = 1;

        private static DeleteMode _deleteMode = DeleteMode.CascadeDelete;

        private static FamilyMemberList _familyMembers;

        #endregion

        #region Business Properties

        public int FamilyMemberId { get; private set; }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                    IsDirty = true;
                    NotifyPropertyChanged("IsSavable");
                }
            }
        }

        private Gender? _gender;

        public Gender? Gender
        {
            get { return _gender; }
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    NotifyPropertyChanged("Gender");
                    IsDirty = true;
                    NotifyPropertyChanged("IsSavable");
                }
            }
        }

        private DateTime? _dateOfBirth;

        public string DateOfBirth
        {
            get
            {
                if (_dateOfBirth != null)
                    return _dateOfBirth.Value.ToShortDateString();

                return "???";
            }
            set
            {
                var changed = false;
                DateTime dateOfBirth;
                var isValidaDate = DateTime.TryParse(value, out dateOfBirth);

                if (isValidaDate && _dateOfBirth != dateOfBirth)
                {
                    _dateOfBirth = dateOfBirth;
                    changed = true;
                }
                else if (_dateOfBirth != null)
                {
                    _dateOfBirth = null;
                    changed = true;
                }

                if (changed)
                {
                    NotifyPropertyChanged("DateOfBirth");
                    IsDirty = true;
                    NotifyPropertyChanged("IsSavable");
                }
            }
        }

        private int? _parentId;

        public int? ParentId
        {
            get { return _parentId; }
            set
            {
                if (_parentId != value)
                {
                    if (value == null || IsNotOwnAncestor(value))
                    {
                        _parentId = value;
                        NotifyPropertyChanged("ParentId");
                        NotifyPropertyChanged("ParentName");
                        IsDirty = true;
                    }
                }
            }
        }

        public string ParentName
        {
            get
            {
                if (_parentId != null)
                {
                    var parent = GetFamilyMemberById(_parentId.Value);
                    if (parent != null)
                        return parent.Name;
                }

                return string.Empty;
            }
        }

        public DeleteMode DeleteMode
        {
            get { return _deleteMode; }
            set
            {
                if (_deleteMode != value)
                {
                    _deleteMode = value;
                    NotifyPropertyChanged("DeleteMode");
                }
            }
        }

        #endregion

        #region State Properties

        private bool _isDirty;

        public bool IsDirty
        {
            get { return _isDirty; }
            private set
            {
                if (_isDirty != value)
                {
                    _isDirty = value;
                    NotifyPropertyChanged("IsDirty");
                    NotifyPropertyChanged("IsSavable");
                }
            }
        }

        public bool IsValid
        {
            get { return !string.IsNullOrWhiteSpace(_name) && _gender.HasValue; }
        }

        public bool IsSavable
        {
            get { return IsDirty && IsValid && !IsDeleted; }
        }

        private bool _isDeleted;

        public bool IsDeleted
        {
            get { return _isDeleted; }
            private set
            {
                if (_isDeleted != value)
                {
                    _isDeleted = value;
                    NotifyPropertyChanged("IsDeleted");
                    NotifyPropertyChanged("IsSavable");
                }
            }
        }

        #endregion

        #region Constuctor

        private FamilyMember()
        {
            // use factory methods
            FamilyMemberId = _lastId++;
        }

        #endregion

        #region Private business methods

        private bool IsNotOwnAncestor(int? parentId)
        {
            if (parentId == null)
                return true;

            if (parentId.Value == FamilyMemberId)
                return false;

            var ancestor = GetFamilyMemberById(parentId.Value);

            return IsNotOwnAncestor(ancestor.ParentId);
        }

        #endregion

        #region Factory methods

        public static FamilyMember AddNewFamilyMember(int? parentId, string nodeNameToShow)
        {
            var familyMember = new FamilyMember
            {
                ParentId = parentId,
                IsDirty = true
            };
            _familyMembers.Add(familyMember);
            FamilyMemberInfo.AddNewFamilyMemberInfo(familyMember.FamilyMemberId, nodeNameToShow, familyMember.ParentId);

            return familyMember;
        }

        internal static FamilyMember NewFamilyMember(string name, Gender gender, string dateOfBirth, string parentName)
        {
            DateTime? trialDateOfBirth = null;
            if (dateOfBirth != null)
                trialDateOfBirth = DateTime.Parse(dateOfBirth);

            var familyMember = new FamilyMember
            {
                _name = name,
                _gender = gender,
                _dateOfBirth = trialDateOfBirth
            };

            if (!string.IsNullOrEmpty(parentName))
            {
                var parent = GetFamilyMemberByName(parentName);
                if (parent != null)
                    familyMember._parentId = parent.FamilyMemberId;
            }

            return familyMember;
        }

        public static FamilyMember GetFamilyMemberById(int familyMemberId)
        {
            return GetFamilyMemberList().FirstOrDefault(familyMember => familyMember.FamilyMemberId == familyMemberId);
        }

        public static FamilyMember GetFamilyMemberByName(string name)
        {
            return GetFamilyMemberList().FirstOrDefault(familyMember => familyMember.Name == name);
        }

        internal static FamilyMemberList GetFamilyMemberList()
        {
            if (_familyMembers == null)
            {
                _familyMembers = new FamilyMemberList();
                _familyMembers.Load();
            }

            return _familyMembers;
        }

        #endregion

        #region Save & Delete methods

        public void Save()
        {
            IsDirty = false;
            FamilyMemberInfo.Update(FamilyMemberId, Name, ParentId);
        }

        public void Delete()
        {
            Delete(this);
        }

        private static void Delete(FamilyMember familyMember)
        {
            if (_deleteMode == DeleteMode.CascadeDelete)
            {
                var familyMembersArray = _familyMembers.ToArray();
                foreach (var member in familyMembersArray)
                {
                    if (member.ParentId == familyMember.FamilyMemberId)
                        Delete(member);
                }
            }
            else
            {
                var familyMembersArray = _familyMembers.ToArray();
                foreach (var member in familyMembersArray)
                {
                    if (member.ParentId == familyMember.FamilyMemberId)
                    {
                        if (_deleteMode == DeleteMode.BypassDeletedNode)
                            member.ParentId = familyMember.ParentId;
                        else //if (_deleteMode == DeleteMode.OrphanChildNodes)
                            member.ParentId = null;

                        member.Save();
                    }
                }
            }
            familyMember.IsDeleted = true;
            _familyMembers.Remove(familyMember);
            FamilyMemberInfo.Remove(familyMember.FamilyMemberId);
            if (_deleteMode != DeleteMode.CascadeDelete)
                FamilyMemberInfo.GetFamilyMemberInfoList().RaiseResetEvent();
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