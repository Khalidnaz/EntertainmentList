import gql from 'graphql-tag';

export const ADD_USER = gql`
  mutation(
    $firstName: String!
    $lastName: String!
    $email: String!
    $password: String!
  ) {
    createUser(
      user: {
        firstName: $firstName
        lastName: $lastName
        email: $email
        password: $password
      }
    ) {
      firstName
      lastName
      email
    }
  }
`;

export const SIGNIN_USER = gql`
  mutation($username: String!, $password: String!) {
    signinUser(username: $username, password: $password) {
      token
    }
  }
`;