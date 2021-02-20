﻿using PnP.Core.Services;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PnP.Core.Model.Teams
{
    /// <summary>
    /// Public interface to define a collection of Team Channels
    /// </summary>
    [ConcreteType(typeof(TeamChannelCollection))]
    public interface ITeamChannelCollection : IQueryable<ITeamChannel>, IDataModelCollection<ITeamChannel>, IDataModelCollectionLoad<ITeamChannel>, ISupportPaging<ITeamChannel>, IDataModelCollectionDeleteByStringId
    {
        #region Add methods

        /// <summary>
        /// Adds a new channel
        /// </summary>
        /// <param name="name">Display name of the channel</param>
        /// <param name="description">Optional description of the channel</param>
        /// <returns>Newly added channel</returns>
        public Task<ITeamChannel> AddAsync(string name, string description = null);

        /// <summary>
        /// Adds a new channel
        /// </summary>
        /// <param name="name">Display name of the channel</param>
        /// <param name="description">Optional description of the channel</param>
        /// <returns>Newly added channel</returns>
        public ITeamChannel Add(string name, string description = null);

        /// <summary>
        /// Adds a new channel
        /// </summary>
        /// <param name="batch">Batch to use</param>
        /// <param name="name">Display name of the channel</param>
        /// <param name="description">Optional description of the channel</param>
        /// <returns>Newly added channel</returns>
        public Task<ITeamChannel> AddBatchAsync(Batch batch, string name, string description = null);

        /// <summary>
        /// Adds a new channel
        /// </summary>
        /// <param name="batch">Batch to use</param>
        /// <param name="name">Display name of the channel</param>
        /// <param name="description">Optional description of the channel</param>
        /// <returns>Newly added channel</returns>
        public ITeamChannel AddBatch(Batch batch, string name, string description = null);

        /// <summary>
        /// Adds a new channel
        /// </summary>
        /// <param name="name">Display name of the channel</param>
        /// <param name="description">Optional description of the channel</param>
        /// <returns>Newly added channel</returns>
        public Task<ITeamChannel> AddBatchAsync(string name, string description = null);

        /// <summary>
        /// Adds a new channel
        /// </summary>
        /// <param name="name">Display name of the channel</param>
        /// <param name="description">Optional description of the channel</param>
        /// <returns>Newly added channel</returns>
        public ITeamChannel AddBatch(string name, string description = null);

        #endregion

        #region GetByDisplayName implementation

        /// <summary>
        /// Method to select a channel by displayName
        /// </summary>
        /// <param name="displayName">The displayName to search for</param>
        /// <param name="selectors">The expressions declaring the fields to select</param>
        /// <returns>The resulting channel instance, if any</returns>
        public ITeamChannel GetByDisplayName(string displayName, params Expression<Func<ITeamChannel, object>>[] selectors);

        /// <summary>
        /// Method to select a channel by displayName asynchronously
        /// </summary>
        /// <param name="displayName">The displayName to search for</param>
        /// <param name="selectors">The expressions declaring the fields to select</param>
        /// <returns>The resulting channel instance, if any</returns>
        public Task<ITeamChannel> GetByDisplayNameAsync(string displayName, params Expression<Func<ITeamChannel, object>>[] selectors);

        #endregion
    }
}
