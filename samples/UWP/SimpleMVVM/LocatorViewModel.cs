﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using GeekyTool.Core.Services;
using GeekyTool.Services;
using SimpleMVVM.ViewModels;
using SimpleMVVM.Views;

namespace SimpleMVVM
{
    public class LocatorViewModel
    {
        static IContainer container;

        public LocatorViewModel()
        {
            var builder = new ContainerBuilder();

            // Interfaces
            var navigationService = ConfigureNavigationService();
            builder.Register(INavigationService => navigationService);

            // ViewModels
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<DetailViewModel>();

            container = builder.Build();
        }

        public MainViewModel MainViewModel => container.Resolve<MainViewModel>();
        public DetailViewModel DetailViewModel => container.Resolve<DetailViewModel>();

        public INavigationService ConfigureNavigationService()
        {
            var navigationService = new NavigationService();

            navigationService.Configure("MainView", typeof(MainView));
            navigationService.Configure("DetailView", typeof(DetailView));

            return navigationService;
        }
    }
}