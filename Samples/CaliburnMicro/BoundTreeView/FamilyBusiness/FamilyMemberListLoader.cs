using System;

namespace FamilyBusiness
{
    /// <summary>
    /// Helper class to load the data into the <see cref="FamilyMemberList" />.
    /// </summary>
    internal static class FamilyMemberListLoader
    {
        internal static FamilyMemberList Load(this FamilyMemberList familyMemberList)
        {
            familyMemberList.Add(FamilyMember.NewFamilyMember("William the Conqueror", Gender.Male, "1028-01-01", ""));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Robert Curthose", Gender.Male, "1051-01-01", "William the Conqueror"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Richard", Gender.Male, "1054-01-01", "William the Conqueror"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("William II", Gender.Male, "1056-01-01", "William the Conqueror"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Matilda", Gender.Female, null, "William the Conqueror"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Cecilia", Gender.Female, "1068-01-01", "William the Conqueror"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Henry I", Gender.Male, "1028-01-01", "William the Conqueror"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Adeliza", Gender.Female, null, "William the Conqueror"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Constance", Gender.Female, "1057-01-01", "William the Conqueror"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Adela", Gender.Female, "1067-01-01", "William the Conqueror"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Stephen", Gender.Male, "1092-01-01", "Adela"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Empress Matilda", Gender.Female, "1102-02-07", "Henry I"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Henry II", Gender.Male, "1133-03-05", "Empress Matilda"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Geoffrey", Gender.Male, "1134-06-01", "Empress Matilda"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("William FitzEmpress", Gender.Male, "1136-07-22", "Empress Matilda"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Charles Martel", Gender.Male, "690-01-01", ""));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Pépin le Bref", Gender.Male, "715-01-01", "Charles Martel"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Carloman", Gender.Male, "705-01-01", "Charles Martel"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Charlemagne", Gender.Male, "742-04-02", "Pépin le Bref"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Carloman I", Gender.Male, "751-01-01", "Pépin le Bref"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Gisèle", Gender.Female, "757-01-01", "Pépin le Bref"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Pépin", Gender.Male, "762-01-01", "Pépin le Bref"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Pépin le Bossu", Gender.Male, "768-01-01", "Charlemagne"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Charles le Jeune", Gender.Male, "772-01-01", "Charlemagne"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Adélaïde", Gender.Female, null, "Charlemagne"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Rotrude", Gender.Female, "775-01-01", "Charlemagne"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Pépin d'Italie", Gender.Male, "777-01-01", "Charlemagne"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Louis le Pieux", Gender.Male, "778-01-01", "Charlemagne"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Lothaire", Gender.Male, "778-01-01", "Charlemagne"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Berthe", Gender.Female, "779-01-01", "Charlemagne"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Gisèle", Gender.Female, "781-01-01", "Charlemagne"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Hildegarde", Gender.Female, "782-01-01", "Charlemagne"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Théodrade", Gender.Male, "785-01-01", "Charlemagne"));
            familyMemberList.Add(FamilyMember.NewFamilyMember("Hiltrude", Gender.Female, "787-01-01", "Charlemagne"));

            return familyMemberList;
        }
    }
}