﻿using TataApp.ViewModels;

namespace TataApp.Infrastructure
{
    class InstanceLocator
    {
        public MainViewModel Main { get; set; }
        public InstanceLocator()
        {
            Main = new MainViewModel();
        }

    }
}
