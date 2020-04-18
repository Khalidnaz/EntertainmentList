import Vue from 'vue';
import VueApollo from 'vue-apollo';
import { ApolloClient } from 'apollo-client';
import { createHttpLink } from 'apollo-link-http';
import { InMemoryCache } from 'apollo-cache-inmemory';

Vue.use(VueApollo);

// HTTP connection to the API
const httpLink = createHttpLink({
  // You should use an absolute URL here
	uri: 'http://localhost:5000/graphql',
	headers: {
		authorization: localStorage.getItem('token'),
  },
});

// Cache implementation
const cache = new InMemoryCache();

// Create the apollo client
export const apolloClient = new ApolloClient({
  link: httpLink,
	cache,
});

const apolloProvider = new VueApollo({
  defaultClient: apolloClient
});

export default apolloProvider;
