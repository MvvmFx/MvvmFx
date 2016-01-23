using System;
using System.ComponentModel;

namespace FamilyBusiness
{
    public class FamilyMemberInfoList : BindingList<FamilyMemberInfo>
    {
        #region Constuctor

        internal FamilyMemberInfoList()
        {
            // use factory methods
            AllowNew = true;
            this.Load();
        }

        #endregion

        #region Update and Remove methods

        internal void Update(int familyMemberId, string name, int? parentId)
        {
            int affectedIndex;
            FamilyMemberInfo familyMemberInfo;
            FindByFamilyMemberId(familyMemberId, out affectedIndex, out familyMemberInfo);

            familyMemberInfo.Name = name;
            familyMemberInfo.ParentId = parentId;
            var listChangedEventArgs = new ListChangedEventArgs(ListChangedType.ItemChanged, affectedIndex);
            OnListChanged(listChangedEventArgs);
        }

        internal void Remove(int familyMemberId)
        {
            int affectedIndex;
            FamilyMemberInfo familyMemberInfo;
            FindByFamilyMemberId(familyMemberId, out affectedIndex, out familyMemberInfo);

            RemoveItem(affectedIndex);
        }

        internal void RaiseResetEvent()
        {
            var listChangedEventArgs = new ListChangedEventArgs(ListChangedType.Reset, -1);
            OnListChanged(listChangedEventArgs);
        }

        private void FindByFamilyMemberId(int familyMemberId, out int affectedIndex,
            out FamilyMemberInfo familyMemberInfo)
        {
            affectedIndex = -1;
            familyMemberInfo = new FamilyMemberInfo();
            for (var index = 0; index < this.Count; index++)
            {
                if (this[index].FamilyMemberId == familyMemberId)
                {
                    familyMemberInfo = this[index];
                    affectedIndex = index;
                    break;
                }
            }

            if (affectedIndex == -1)
                throw new ArgumentOutOfRangeException("familyMemberId");
        }

        #endregion
    }
}