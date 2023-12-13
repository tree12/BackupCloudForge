using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EDI.DataAccess.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Portal.Common.Entity.Abstracts;
using Portal.Common.Entity.Interfaces;
using EDI.DataAccess.Entities;
using EDI.DataAccess.Entities.Attributes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using Namotion.Reflection;

namespace EDI.DataAccess.Entities.Codes
{
    public abstract class BaseCodeEntity<TEntity> : BaseObject<TEntity, string> where TEntity : EntityObjectWithConfig<TEntity, string>
    {
        //public string Key { get; set; }
        public string Value { get; set; }

        /// <summary>
        /// Parse using ^[| ]*(\d+)\s+([^\r\n]+)
        /// https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.match.groups?view=net-6.0 
        /// </summary>
        public abstract string CodeDefinitionText { get; }
        public abstract string StringCodeDefinitionText { get; }  //remove

        [Column(TypeName = "nvarchar")]
        [MaxLength(100)]
        [NotSave]
        public string German { get; set; }

        [NotSave]
        public bool InUse { get; set; }
        public override void Configure(EntityTypeBuilder<TEntity> b)
        {
            b.Ignore(p => p.Deleted);
            //b.Property(e => e.Id).ValueGeneratedOnAdd();
            b.ToTable(this.GetType().Name)
                .HasKey(t => t.Id);
            b.Property(t => t.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
        }
        public static void IterateAllCodes<T>(ApplicationDbContext dbContext) where T: BaseCodeEntity<T>
        {
            List<Type> allcodeTypes = typeof(BaseCodeEntity<TEntity>).Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(BaseCodeEntity<TEntity>))).ToList();
            List<BaseCodeEntity<TEntity>> results = new List<BaseCodeEntity<TEntity>>();
            foreach (Type codeType in allcodeTypes)
            {
                //Maybe this would be a better Regex because we not have to use 2 regex
                // ^[| \+]*((\d+)|([A-Z0-9]{1,3}))\s+([^\r\n]+)
                BaseCodeEntity<TEntity> instance = Activator.CreateInstance(codeType) as BaseCodeEntity<TEntity>;
                Regex r = new Regex(@"^[| \+]*(\d+)\s+([^\r\n]+)", RegexOptions.Multiline);
                //instance.CodeDefinitionText  //scan with regex and for each match add redord to the db
                MatchCollection matches = !string.IsNullOrEmpty(instance.CodeDefinitionText)? r.Matches(instance.CodeDefinitionText): null;
                if (!string.IsNullOrWhiteSpace(instance.StringCodeDefinitionText))
                {
                    Regex extraR = new Regex(@"^[| \+]*(\w+)\s+([^\r\n]+)", RegexOptions.Multiline);
                    MatchCollection matches2 = extraR.Matches(instance.StringCodeDefinitionText);
                    IEnumerable<Match> combined = matches!=null? matches.OfType<Match>().Concat(matches2.OfType<Match>()).Where(m => m.Success): matches2;
                    assignToDb<T>(combined, codeType, dbContext);
                }
                else
                {
                    if(matches!=null)
                        assignToDb<T>(matches, codeType, dbContext);
                }

            }

            dbContext.SaveChanges();
        }

        private static void assignToDb<T>(IEnumerable<Match> matches, Type codeType, ApplicationDbContext dbContext) where T : BaseCodeEntity<T>
        {
            foreach (Match match in matches)
            {
                BaseCodeEntity<T> entity = Activator.CreateInstance(codeType) as BaseCodeEntity<T>;
                entity.Id = match.Groups[1].Value;
                entity.Value = match.Groups[2].Value;

                //bool exist = dbContext.Set<T>().AddIfNotExists<T>((T)entity, pi => pi.Id == entity.Id);
                var existEntity = dbContext.Set<T>().FirstOrDefault(x => x.Id == entity.Id);
                if (existEntity != null)
                {
                    dbContext.Update(existEntity);
                    PropertyInfo[] props = codeType.GetProperties();
                    foreach (var prop in props)
                    {
                        object[] attrs = prop.GetCustomAttributes(true);
                        object notSaveAttr = attrs.FirstOrDefault(attr => attr.GetType() == typeof(NotSaveAttribute));

                        if (notSaveAttr != null)
                        {
                            dbContext.Entry(existEntity).Property(prop.Name).IsModified = false;
                        }
                        else if (prop.CanWrite)
                        {
                            prop.SetValue(existEntity, prop.GetValue(entity));
                        }

                    }
                    //dbContext.Entry(entity).Property(x => x.German).IsModified = false;
                    //dbContext.Entry(entity).Property(x => x.Usage).IsModified = false;

                }
                else
                {
                    dbContext.Add(entity);
                }
            }
        }


    }
}
