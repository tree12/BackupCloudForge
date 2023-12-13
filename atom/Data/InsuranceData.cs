using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATom.CommonDB.DataObjects;
using BedarfsCheck.Controllers;

namespace BedarfsCheck.Data
{
    [Table("tbl_Insurance")]
    public class InsuranceData : BaseDataObject
    {

        public InsuranceData()
        {

        }

        public InsuranceData(string namePk)
        {
            Name_PK = namePk;
        }

        private Dictionary<string, int> _levelDict = new Dictionary<string, int>();

        [PrimaryKey]
        [Field]
        public string Name_PK { get; set; }

        [Field]
        public string Description { get; set; }

        [Field(FieldAttribute.DBColType.Text)]
        public string HtmlText { get; set; }

        public void SetLevelForItem(string itemName, int level)
        {
            _levelDict[itemName] = level;
        }

        public Dictionary<string, int> LevelDict
        {
            get => _levelDict;
            set => _levelDict = value;
        }

        private int _level = -1;
        public int Level => _level;

        public void CalcLevel(List<MainController.Item> items)
        {
            _level = 0;
            foreach (MainController.Item item in items.Where(_ => _.Selected))
            {
                if (!_levelDict.ContainsKey(item.Name)) continue;
                _level += _levelDict[item.Name];
            }
        }
    }

    [Table("tbl_InsuranceLevels")]
    public class InsuranceLevelData : BaseDataObject
    {
        [PrimaryKey]
        [Field]
        public string Insurance_Name_PK { get; set; }

        [PrimaryKey]
        [Field]
        public string Option_Name_PK { get; set; }

        [Field]
        public int Level { get; set; }
    }
}
