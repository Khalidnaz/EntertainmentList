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
  mutation($email: String!, $password: String!) {
    login(input: { email: $email, password: $password }) {
      id
      firstName
      lastName
      email
      token
    }
  }
`;
