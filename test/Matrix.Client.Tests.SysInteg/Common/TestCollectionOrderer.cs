using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Matrix.Client.Tests.SysInteg.Common
{
    public class TestCollectionOrderer : ITestCollectionOrderer
    {
        private readonly string[] _orderedCollections = {
            CommonConstants.TestCollections.ApiStandards,
            CommonConstants.TestCollections.InitialSessionManagement,
            CommonConstants.TestCollections.RoomListing,
            CommonConstants.TestCollections.ContentRepository,
            CommonConstants.TestCollections.EventSending,

            CommonConstants.TestCollections.FinalSessionManagement
        };

        public IEnumerable<ITestCollection> OrderTestCollections(IEnumerable<ITestCollection> testCollections)
        {
            testCollections = testCollections.OrderBy(FindExecutionOrder);

            foreach (var collection in testCollections)
            {
                yield return collection;
            }
        }

        private int FindExecutionOrder(ITestCollection collection)
        {
            int? order = null;
            for (int i = 0; i < _orderedCollections.Length; i++)
            {
                if (_orderedCollections[i] == collection.DisplayName)
                {
                    order = i;
                    break;
                }
            }

            if (order is null)
            {
                throw new Exception($"Collection \"{collection.DisplayName}\" not found in execution list.");
            }

            return (int)order;
        }
    }
}
