﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PnP.Core.Transformation.Services.MappingProviders;

namespace PnP.Core.Transformation.SharePoint.MappingProviders
{
    /// <summary>
    /// SharePoint implementation of <see cref="ITaxonomyMappingProvider"/>
    /// </summary>
    public class SharePointTaxonomyMappingProvider : ITaxonomyMappingProvider
    {
        /// <summary>
        /// Maps a Taxonomy Term from the source platform to the target platform
        /// </summary>
        /// <param name="input">The input for the mapping activity</param>
        /// <returns>The output of the mapping activity</returns>
        public Task<TaxonomyMappingProviderOutput> MapTermAsync(TaxonomyMappingProviderInput input)
        {
            return Task.FromResult(new TaxonomyMappingProviderOutput());
        }
    }
}
