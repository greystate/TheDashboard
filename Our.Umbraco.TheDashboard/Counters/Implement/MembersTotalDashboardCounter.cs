﻿using LightInject;
using Umbraco.Core.Scoping;
using Umbraco.Core.Services;

namespace Our.Umbraco.TheDashboard.Counters.Implement
{
    public class MembersTotalDashboardCounter : IDashboardCounter
    {
        private readonly ILocalizedTextService  _localizedTextService;

        public MembersTotalDashboardCounter(ILocalizedTextService  localizedTextService)
        {
            _localizedTextService = localizedTextService;
        }

        public DashboardCounterModel GetModel(IScope scope)
        {
            var count = scope.Database.ExecuteScalar<int>(@"select COUNT(nodeId) from cmsMember");
            
            return new DashboardCounterModel()
            {
                Text = _localizedTextService.Localize("theDashboard/membersOnWebsite"),
                Count = count,
                ClickUrl = "/umbraco#/member",
                Style = DashboardCounterModel.CounterStyles.Selected
            };
        }
    }
}