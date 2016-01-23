namespace FamilyBusiness
{
    internal static class FamilyMemberInfoListLoader
    {
        internal static FamilyMemberInfoList Load(this FamilyMemberInfoList familyMemberInfoList)
        {
            foreach (var familyMember in FamilyMember.GetFamilyMemberList())
            {
                familyMemberInfoList.Add(FamilyMemberInfo.NewFamilyMemberInfo(familyMember.FamilyMemberId,
                    familyMember.Name, familyMember.ParentId));
            }

            return familyMemberInfoList;
        }
    }
}