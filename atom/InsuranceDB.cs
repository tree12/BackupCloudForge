using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATom.CommonDB.DB;
using BedarfsCheck.Data;
using BedarfsCheck.Controllers;
using Microsoft.AspNetCore.Server.Kestrel.Transport.Abstractions.Internal;

namespace BedarfsCheck
{
    public static class InsuranceDB
    {
        static public List<InsuranceData> LoadInsurances()
        {            
            DBBaseObject<InsuranceData> insuranceDB = new DBBaseObject<InsuranceData>(Global.Connection);
            List<InsuranceData> insuranceList = insuranceDB.SelectObjects();
            DBBaseObject<InsuranceLevelData> insuranceLevelDB = new DBBaseObject<InsuranceLevelData>(Global.Connection);
            foreach (InsuranceData insurance in insuranceList)
            {
                FillInsurance(insuranceLevelDB, insurance);
            }
            return insuranceList;
        }

        static public InsuranceData LoadInsurance(string name_PK)
        {
            DBBaseObject<InsuranceData> insuranceDB = new DBBaseObject<InsuranceData>(Global.Connection);
            DBBaseObject<InsuranceLevelData> insuranceLevelDB = new DBBaseObject<InsuranceLevelData>(Global.Connection);
            InsuranceData insurance = insuranceDB.SelectObjects($"name_PK='{name_PK}'").FirstOrDefault();
            if (insurance == null) return null;
            {
                FillInsurance(insuranceLevelDB, insurance);
            }
            return insurance;
        }

        private static void FillInsurance(DBBaseObject<InsuranceLevelData> insuranceLevelDB, InsuranceData insurance)
        {
            List<InsuranceLevelData> levels = insuranceLevelDB.SelectObjects($"Insurance_Name_PK='{insurance.Name_PK}'");
            Dictionary<string, int> levelDict = new Dictionary<string, int>();
            foreach (var level in levels)
            {
                levelDict[level.Option_Name_PK] = level.Level;
            }
            insurance.LevelDict = levelDict;
        }

        static public void SaveInsurance(InsuranceData insurance)
        {
            DBBaseObject<InsuranceData> insuranceDB = new DBBaseObject<InsuranceData>(Global.Connection);
            List<InsuranceData> insuranceList = insuranceDB.SelectObjects();
            DBBaseObject<InsuranceLevelData> insuranceLevelDB = new DBBaseObject<InsuranceLevelData>(Global.Connection);
            insuranceDB.Update(insurance);
            insuranceLevelDB.ExecuteNonQuery(
                $"DELETE FROM tbl_InsuranceLevels where Insurance_Name_PK='{insurance.Name_PK}'");
            foreach (KeyValuePair<string, int> pair in insurance.LevelDict)
            {
                insuranceLevelDB.Insert(new InsuranceLevelData()
                {
                    Insurance_Name_PK = insurance.Name_PK,
                    Option_Name_PK = pair.Key,
                    Level = pair.Value
                });
            }
        }
    }
}
