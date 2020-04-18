<template>
  <v-container mt-5>
    <v-row justify="center">
      <h1>Register</h1>
    </v-row>
    <v-card class="mx-auto mt-5" color="secondary" dark max-width="800">
      <v-form lazy-validation ref="form" @submit.prevent="handleRegister">
        <v-row justify="center">
          <v-col cols="6">
            <v-text-field
              v-bind:rules="firstNameRules"
              v-model="firstName"
              prepend-icon="mdi-face"
              label="First Name"
              type="text"
              required
            ></v-text-field>
          </v-col>
        </v-row>

        <v-row justify="center">
          <v-col cols="6">
            <v-text-field
              v-bind:rules="lastNameRules"
              v-model="lastName"
              prepend-icon="mdi-face"
              label="Last Name"
              type="text"
              required
            ></v-text-field>
          </v-col>
        </v-row>

        <v-row justify="center">
          <v-col cols="6">
            <v-text-field
              v-bind:rules="emailRules"
              v-model="email"
              prepend-icon="mdi-email"
              label="Email"
              type="email"
              required
            ></v-text-field>
          </v-col>
        </v-row>

        <v-row justify="center">
          <v-col cols="6">
            <v-text-field
              v-bind:rules="passwordRules"
              v-model="password"
              prepend-icon="mdi-lock"
              label="Password"
              type="password"
              required
            ></v-text-field>
          </v-col>
        </v-row>

        <v-row justify="center">
          <v-col cols="6">
            <v-text-field
              v-bind:rules="passwordRules"
              v-model="confirmPassword"
              prepend-icon="mdi-gavel"
              label="Comfirm Password"
              type="password"
              required
            ></v-text-field>
          </v-col>
        </v-row>

        <v-row justify="center">
          <v-col cols="1">
            <v-progress-circular
              v-if="loading"
              indeterminate
              color="accent"
            ></v-progress-circular>
            <v-btn
              v-else
              v-bind:disabled="loading"
              color="accent"
              type="submit"
            >
              Register
            </v-btn>
          </v-col>
        </v-row>
        <v-row>
          <v-col col="6">
            <h3 class="text-center">
              Already have an account?
              <router-link to="/login">Sign In</router-link>
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
  name: 'Register',
  computed: {
    ...mapGetters(['error', 'loading', 'user']),
  },
  watch: {
    user(value) {
      if (value) {
        this.$router.push('/');
      }
    },
  },
  data() {
    return {
      firstName: '',
      lastName: '',
      email: '',
      password: '',
      confirmPassword: '',
      firstNameRules: [(firstName) => !!firstName || 'First Name is required'],
      lastNameRules: [(lastName) => !!lastName || 'Last Name is required'],
      emailRules: [
        (email) => !!email || 'Email is required',
        (email) => /.@+./.test(email) || 'Email must be valid',
      ],
      passwordRules: [
        (password) => !!password || 'Password is required',
        (password) =>
          password.length >= 4 || 'Password must be at least 4 characters',
        (confirmation) =>
          confirmation === this.password || 'Password must match',
      ],
    };
  },
  methods: {
    handleRegister() {
      if (
        this.$refs.form.validate() &&
        this.password === this.confirmPassword
      ) {
        this.$store.dispatch('registerUser', {
          firstName: this.firstName,
          lastName: this.lastName,
          email: this.email,
          password: this.password,
				});
      }
    }
  },
};
</script>
