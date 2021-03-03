using Abp.Dependency;
using GraphQL.Types;
using GraphQL.Utilities;
using MCV.Portal.Queries.Container;
using System;

namespace MCV.Portal.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IServiceProvider provider) :
            base(provider)
        {
            Query = provider.GetRequiredService<QueryContainer>();
        }
    }
}