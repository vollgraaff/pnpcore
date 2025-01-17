﻿using System.Collections.Generic;

namespace PnP.Core.Model.SharePoint
{
    [GraphType(Uri = "sites/{hostname},{Site.Id},{Web.Id}/termstore")]
    internal sealed class TermStore : BaseDataModel<ITermStore>, ITermStore
    {
        #region Properties
        public string Id { get => GetValue<string>(); set => SetValue(value); }

        [GraphProperty("defaultLanguageTag")]
        public string DefaultLanguage { get => GetValue<string>(); set => SetValue(value); }

        [GraphProperty("languageTags")]
        public List<string> Languages { get => GetValue<List<string>>(); set => SetValue(value); }

        [GraphProperty("groups", Get = "sites/{hostname},{Site.Id},{Web.Id}/termstore/groups")]
        public ITermGroupCollection Groups { get => GetModelCollectionValue<ITermGroupCollection>(); }

        [KeyProperty(nameof(Id))]
        public override object Key { get => Id; set => Id = value.ToString(); }
        #endregion
    }
}