using EntertainmentList.Graphql;
using HotChocolate.Types;

// example here https://github.com/ChilliCream/hotchocolate/tree/master/examples/AspNetCore.StarWars

namespace EntertainmentList.Types
{
	public class QueryType : ObjectType<Query>
	{
		protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
		{
			descriptor.Field(t => t.Hello())
					.Type<StringType>();


			// descriptor.Field(t => t.GetCharacter(default, default))
			// 		.Type<NonNullType<ListType<NonNullType<CharacterType>>>>();

			// // the search can only be executed if the current
			// // identity has a country
			// descriptor.Field(t => t.Search(default))
			// 		.Type<ListType<SearchResultType>>()
			// 		.Authorize("HasCountry");
		}
	}
}