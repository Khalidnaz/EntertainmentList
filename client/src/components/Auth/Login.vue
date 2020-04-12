<template>
  <v-container mt-5>
    <v-row justify="center">
      <h1>Welcome Back!</h1>
    </v-row>
    <v-card class="mx-auto mt-5" color="secondary" dark max-width="800">
      <v-form v-model="isFormValid" lazy-validation ref="form">
        <v-row justify="center">
          <v-col cols="6">
            <v-text-field
              v-bind:rules="usernameRules"
              v-model="username"
              prepend-icon="mdi-face"
              label="Username"
              type="text"
              required
            ></v-text-field>
          </v-col>
        </v-row>

        <v-row justify="center">
          <v-col cols="6">
            <v-text-field
              v-bind:rules="usernameRules"
              v-model="username"
              prepend-icon="mdi-lock"
              label="Password"
              type="text"
              required
            ></v-text-field>
          </v-col>
        </v-row>

        <v-row justify="center">
          <v-col cols="1">
            <v-btn
              v-bind:loading="loading"
              v-bind:disabled="!isFormValid || loading"
              color="accent"
              type="submit"
            >
              <!-- This can be its own component -->
              <span slot="loader" class="custom-loader">
                <v-icon light>mdi-cached</v-icon>
              </span>
              Sign in
            </v-btn>
          </v-col>
        </v-row>
        <v-row>
          <v-col col="6">
            <h3 class="text-center">
              Don't have an account?
              <router-link to="/register">Sign up</router-link>
            </h3>
          </v-col>
        </v-row>
      </v-form>
    </v-card>
  </v-container>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
  name: 'Login',
  computed: {
    ...mapGetters(['user', 'error', 'loading'])
  },
  data() {
    return {
      username: '',
      password: '',
      // form validation rules, we set an array of conditions
      usernameRules: [
        // check if username in input
        username => !!username || 'Username is required',
        // make sure username is less than 10 characters
        username =>
          username.length < 10 || 'Username must be less than 10 characters'
      ],
      passwordRules: [
        password => !!password || 'Password is required',
        // Make sure password is at least 7 characters
        password =>
          password.length >= 7 || 'Password must be at least 7 characters'
      ],
      isFormValid: true
    };
  }
};
</script>

<style></style>
