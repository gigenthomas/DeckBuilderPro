using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.Entity;
using DeckBuilderPro.Data.Configuration;
using IRepository;
using DeckBuilderPro.Entity;
using VsSystem = DeckBuilderPro.Data.Configuration.VsSystem;

namespace DeckBuilderPro.Data
{
    public class DataContext : BaseDataContext
    {

        public static string ConnectionStringName
        {
            get
            {
                if (ConfigurationManager.AppSettings[Constants.AppSettings.ConnectionString]
                    != null)
                {
                    return ConfigurationManager.
                        AppSettings[Constants.AppSettings.ConnectionString].ToString();
                }

                return Constants.AppSettings.DefaultConnectionStringName;
            }
        }

        static DataContext()
        {
            Database.SetInitializer<BaseDataContext>(null);
        }

        public DataContext()
            : base(nameOrConnectionString: DataContext.ConnectionStringName)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public override void AddModelBuilderConfiguration(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add<Card>( new CardConfiguration());
            modelBuilder.Configurations.Add(new CardConfiguration());
            modelBuilder.Configurations.Add(new CardRarityConfiguration());
            modelBuilder.Configurations.Add(new CardTypeConfiguration());
            modelBuilder.Configurations.Add(new DeckConfiguration());
            modelBuilder.Configurations.Add(new DeckCardConfiguration());
            modelBuilder.Configurations.Add(new FormatConfiguration());
            modelBuilder.Configurations.Add(new GameConfiguration());
            modelBuilder.Configurations.Add(new GamesSetConfiguration());
            modelBuilder.Configurations.Add(new ManufacturerConfiguration());
            modelBuilder.Configurations.Add(new VsSystem_CardConfiguration());
            modelBuilder.Configurations.Add(new VsSystem_CardTextsConfiguration());
            modelBuilder.Configurations.Add(new VsSystem_TeamAffiliationConfiguration());
            modelBuilder.Configurations.Add(new CollectionCardConfiguration());
            
            //Register Vs System Model Configurations

            modelBuilder.Configurations.Add(new VsSystem.CardConfiguration());
            modelBuilder.Configurations.Add(new VsSystem.CardRarityConfiguration());
            modelBuilder.Configurations.Add(new VsSystem.CardTypeConfiguration());
            modelBuilder.Configurations.Add(new VsSystem.CollectionCardConfiguration());
            modelBuilder.Configurations.Add(new VsSystem.CollectionConfiguration());
            modelBuilder.Configurations.Add(new VsSystem.DeckCardConfiguration());
            modelBuilder.Configurations.Add(new VsSystem.DeckConfiguration());
            modelBuilder.Configurations.Add(new VsSystem.TeamAffiliationsConfiguration());
        
        }

    }
}
