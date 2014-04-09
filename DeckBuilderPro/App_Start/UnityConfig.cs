using DeckBuilderPro.DataManager;
using DeckBuilderPro.DataManager.Interfaces;
using DeckBuilderPro.DataManagers;
using DeckBuilderPro.DataManagers.Interfaces;
using DeckBuilderPro.Entity;
using DeckBuilderPro.ViewModels;
using DeckBuilderPro.ViewModels.Interfaces;
using DeckBuilderPro.ViewModels.ViewModelsBuilders;
using IRepository;
using Microsoft.Practices.Unity;
using System.Web.Http;
using UnityWebApi = Unity.WebApi;
using UnityMvc = Unity.Mvc4;
using Enums = DeckBuilderPro.Entity.Enums;
using System.Web.Mvc;
using IMapping;
using DeckBuilderPro.Unity;


namespace DeckBuilderPro
{
    public static class UnityConfig
    {
        public static void Initialise()
        {
            var container = UnityConfiguration.BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityMvc.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new UnityWebApi.UnityDependencyResolver(container);
        }
    }
}